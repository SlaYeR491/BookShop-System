using BookShop.Data;

namespace BookShop.Domain.Interfaces
{
    public interface ICustomerBooksServices : ICRUD<CustomerBook>
    {
        public ValueTask<IEnumerable<CustomerBook>?> ReadAllAsync(int customerId);
    }
}
