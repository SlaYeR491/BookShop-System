using BookShop.Data;
using BookShop.Domain.Interfaces;

namespace BookShop.Application.Services
{
    public class AdminServices(IRepository<AdminAccount> _repo) : IAdminServices
    {
        public async ValueTask<bool> IsActiveAsync(object accountId)
        {
            var acc = await _repo.ReadAsync(accountId);
            if (acc != null)
                return acc.IsActive;
            return false;
        }

        public async ValueTask<AdminAccount?> LoginAsync(AdminAccount account)
        {
            var acc = await _repo.ReadAsync(a => a.UserName == account.UserName &&
            a.Password == account.Password);
            if (acc == null)
                return null;
            acc.IsActive = true;
            _repo.Update(acc);
            _repo.SaveChanges();
            return acc;
        }
    }
}
