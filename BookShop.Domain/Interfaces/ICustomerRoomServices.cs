using BookShop.Data;

namespace BookShop.Domain.Interfaces
{
    public interface ICustomerRoomServices : ICRUD<CustomerRoom>
    {
        public ValueTask<CustomerRoom?> JoinAsync(CustomerRoom customerRoom);
        public ValueTask<IEnumerable<CustomerRoom>?> ReadAllAsync(object CustomerId);
    }
}
