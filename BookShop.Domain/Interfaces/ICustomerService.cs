using BookShop.Data;

namespace BookShop.Domain.Interfaces
{
    public interface ICustomerService : ICRUD<CustomerAccount>
    {
        public ValueTask<CustomerAccount?> CheckValidEmail(string Email);
    }
}
