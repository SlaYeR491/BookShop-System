using BookShop.API.Configurations;
using BookShop.API.Options;
using BookShop.Domain.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookShop.API.Aggregates
{
    public class JwtServices(IOptions<JwtOptions> options,
        ICustomerService customerService)
    {
        private readonly JwtSecurityTokenHandler _jwtHandler = new();
        private readonly SecurityTokenDescriptor _descriptor = new SecurityTokenDescriptor
        {
            Audience = options.Value.Audience,
            Issuer = options.Value.Issuer,
            Expires = DateTime.UtcNow.AddMinutes(options.Value.LifeTime),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.SigningKey)),
                SecurityAlgorithms.HmacSha256)
        };
        public string CreateToken(ClaimsIdentity claims)
        {
            claims.AddClaim(new Claim(ClaimTypes.Expiration, DateTime.UtcNow.AddMinutes(options.Value.LifeTime).ToString()));
            _descriptor.Subject = claims;
            var token = _jwtHandler.CreateToken(_descriptor);
            return _jwtHandler.WriteToken(token);
        }
        private TokenValidationParameters Copy(TokenValidationParameters source)
        {
            var sourceprop = source.GetType().GetProperties();
            TokenValidationParameters target = new();
            foreach (var prop in sourceprop)
            {
                var value = prop.GetValue(source);
                if (value != null && prop.CanWrite)
                    prop.SetValue(target, value);
            }
            return target;
        }
        public async ValueTask<string> CreateRefreshTokenAsync(string oldtoken, int accountId)
        {
            if (!await customerService.IsActiveAsync(accountId))
                return "Must Login First";
            var validationparameters = Copy(JwtConfigure.validationParameters);
            validationparameters.ValidateLifetime = false;
            try
            {
                var claimsPrincipal = _jwtHandler.ValidateToken(oldtoken, validationparameters, out var _discard);
                var claims = claimsPrincipal.Identity as ClaimsIdentity;
                if (!claims.Claims.Any(a => a.Type == ClaimTypes.NameIdentifier && a.Value == accountId.ToString()))
                    return "Not Authorized";
                var expDate = DateTime.Parse(claims.Claims.FirstOrDefault(a => a.Type == ClaimTypes.Expiration).Value);
                if (expDate > DateTime.UtcNow)
                    return "Not Expired Yet";
                _descriptor.Expires = DateTime.UtcNow.AddHours(10);
                claims.AddClaim(new(ClaimTypes.Expiration, _descriptor.Expires.ToString()));
                _descriptor.Subject = claims;
                var newtoken = _jwtHandler.CreateToken(_descriptor);
                return _jwtHandler.WriteToken(newtoken);
            }
            catch (Exception)
            {
                await customerService.UnSetActive(accountId);
                return "Invakid Token";
            }
        }
    }
}
