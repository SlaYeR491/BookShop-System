using BookShop.Data;

namespace BookShop.Domain.Interfaces
{
    public interface ICustomerService : ICRUD<CustomerAccount>
    {
        public ValueTask<CustomerAccount?> LoginAsync(CustomerAccount account);
        public ValueTask<CustomerAccount?> CheckValidEmailAsync(string Email);
        public ValueTask<bool> IsActiveAsync(object accountId);
        public ValueTask UnSetActive(object accountId);
    }
}
