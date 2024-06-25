using BookShop.API.Aggregates;
using BookShop.API.Configurations;
using BookShop.API.Mapping;
using BookShop.API.Options;
using BookShop.Application.Services;
using BookShop.Domain.Interfaces;
using BookShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace BookShop.API.Extensions
{
    public static class Registeration
    {
        public static void Register(this IServiceCollection services, IConfiguration configuration)
        {
            var jwt = configuration.GetSection("Jwt").Get<JwtOptions>();
            JwtConfigure.AddJwtToken(services, jwt);
            services.
                AddDbContext<AppDbContext>(op =>
                {
                    op.UseSqlServer(configuration.GetConnectionString("sql"));
                })
               .AddScoped(typeof(IRepository<>), typeof(Repository<>))
               .AddScoped<IAdminServices, AdminServices>()
               .AddScoped<ICustomerService, CustomerServices>()
               .AddScoped<IBookServices, BookServices>()
               .AddScoped<ICustomerBooksServices, CustomerBooksServices>()
               .AddScoped<IPaymentServices, PaymentServices>()
               .AddScoped<IRoomServices, RoomServices>()
               .AddScoped<IRoomDetailServices, RoomDetailServices>()
               .AddScoped<ICustomerRoomServices, CustomerRoomServices>()
               .Configure<JwtOptions>(configuration.GetSection("Jwt"))
               .AddScoped<JwtServices>()
               .AddScoped(typeof(Mapper<,>))
               .AddScoped<Hashing>();
            IOptions<MemoryCacheOptions> options = new MemoryCacheOptions
            {
                SizeLimit = 1000
            };
            IMemoryCache mem = new MemoryCache(options);
            services
                .AddSingleton(mem);

        }
    }
}
