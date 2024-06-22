using BookShop.API.Aggregates;
using BookShop.API.Configurations;
using BookShop.API.Mapping;
using BookShop.Application.Services;
using BookShop.Domain.Interfaces;
using BookShop.Infrastructure.Data;

namespace BookShop.API.Extensions
{
    public static class Registeration
    {
        public static IServiceCollection Register(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped<IAdminServices, AdminServices>()
                .AddScoped<ICustomerService, CustomerServices>()
                .AddScoped<IBookServices, BookServices>()
                .AddScoped<ICustomerBooksServices, CustomerBooksServices>()
                .AddScoped<IPaymentServices, PaymentServices>()
                .AddScoped<IRoomServices, RoomServices>()
                .AddScoped<IRoomDetailServices, RoomDetailServices>()
                .AddScoped<ICustomerRoomServices, CustomerRoomServices>()
                .AddScoped<JwtServices>()
                .AddScoped(typeof(Mapper<,>))
                .AddScoped<Hashing>()
                ;
        }
    }
}
