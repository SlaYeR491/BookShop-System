using BookShop.Data;
using BookShop.Domain.Interfaces;

namespace BookShop.Application.Services
{
    public class AdminServices(IRepository<AdminAccount> _repo) : IAdminServices
    {
        public async ValueTask<AdminAccount?> Login(AdminAccount account)
        {
            return await _repo.ReadAsync(a => a.UserName == account.UserName &&
            a.Password == account.Password);
        }
    }
}
