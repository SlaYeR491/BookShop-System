using BookShop.API.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BookShop.API.Configurations
{
    public static class JwtConfigure
    {
        public static TokenValidationParameters validationParameters => parameters;
        private static TokenValidationParameters parameters;
        public static void AddJwtToken(IServiceCollection services, JwtOptions jwt)
        {
            parameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.SigningKey)),
                ValidIssuer = jwt.Issuer,
                ValidAudience = jwt.Audience
            };
            services.AddAuthentication()
                .AddJwtBearer("Bearer", op =>
            {
                op.SaveToken = true;
                op.TokenValidationParameters = validationParameters;
            });
        }
    }
}
