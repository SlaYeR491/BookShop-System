using BookShop.Data;

namespace BookShop.Domain.Interfaces
{
    public interface IAdminServices
    {
        public ValueTask<AdminAccount?> Login(AdminAccount account);
    }
}
