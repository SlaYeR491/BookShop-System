using BookShop.API.Aggregates;
using BookShop.API.Extensions;
using BookShop.API.Mapping;
using BookShop.API.Options;
using BookShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("sql"));
});
builder.Services.Register();

var jwt = builder.Configuration.GetSection("Jwt").Get<JwtOptions>();
builder.Services.AddAuthentication()
    .AddJwtBearer("Bearer", op =>
    {
        op.SaveToken = true;
        op.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.SigningKey)),
            ValidIssuer = jwt.Issuer,
            ValidAudience = jwt.Audience

        };
    });

builder.Services.AddSingleton<JwtServices>()
                .AddScoped(typeof(Mapper<,>))
                .AddScoped<Hashing>()
                .AddSingleton(jwt);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
