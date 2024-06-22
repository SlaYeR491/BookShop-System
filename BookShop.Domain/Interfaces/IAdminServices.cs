using BookShop.Data;

namespace BookShop.Domain.Interfaces
{
    public interface IAdminServices
    {
        public ValueTask<AdminAccount?> LoginAsync(AdminAccount account);
        public ValueTask<bool> IsActiveAsync(object accountId);
    }
}
