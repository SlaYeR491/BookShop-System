using BookShop.API.Configurations;
using BookShop.API.Extensions;
using BookShop.API.Options;
using BookShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("sql"));
});

var jwt = builder.Configuration.GetSection("Jwt").Get<JwtOptions>();
new JwtConfigure(builder.Services, jwt).AddJwtToken();
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));

builder.Services.Register();

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
