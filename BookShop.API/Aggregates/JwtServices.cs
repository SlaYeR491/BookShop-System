using BookShop.API.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookShop.API.Aggregates
{
    public class JwtServices
    {
        private readonly JwtSecurityTokenHandler _jwtHandler;
        private readonly JwtOptions options;

        public JwtServices(JwtOptions Options)
        {
            _jwtHandler = new JwtSecurityTokenHandler();
            options = Options;
        }
        public string Create(ClaimsIdentity claims)
        {
            var descriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Audience = options.Audience,
                Issuer = options.Issuer,
                Expires = DateTime.UtcNow.AddMinutes(options.LifeTime),
                SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SigningKey)),
                SecurityAlgorithms.HmacSha256)
            };
            var token = _jwtHandler.CreateToken(descriptor);
            return _jwtHandler.WriteToken(token);
        }
    }
}
