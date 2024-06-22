using BookShop.API.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BookShop.API.Configurations
{
    public class JwtConfigure(IServiceCollection services, JwtOptions jwt)
    {
        public TokenValidationParameters validationParameters => new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.SigningKey)),
            ValidIssuer = jwt.Issuer,
            ValidAudience = jwt.Audience

        };
        public void AddJwtToken()
        {
            services.AddAuthentication()
                .AddJwtBearer("Bearer", op =>
            {
                op.SaveToken = true;
                op.TokenValidationParameters = validationParameters;
            });
        }
    }
}
