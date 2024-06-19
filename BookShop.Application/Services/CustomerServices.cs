using BookShop.Data;
using BookShop.Domain.Interfaces;

namespace BookShop.Application.Services
{
    public class CustomerServices(IRepository<CustomerAccount> _repo) : ICustomerService
    {
        public async ValueTask<CustomerAccount?> AddAsync(CustomerAccount account)
        {
            var Exist = await CheckValidEmail(account.UserName);
            if (Exist != null) return null;
            await _repo.CreateAsync(account);
            await _repo.SaveChangesAsync();
            return account;
        }

        public async ValueTask<CustomerAccount?> CheckValidEmail(string Email)
        {
            return await _repo.ReadAsync(a => a.UserName == Email);
        }

        public async ValueTask<CustomerAccount?> DeleteAsync(object accountId)
        {
            var Exist = await ReadAsync(accountId);
            if (Exist == null) return null;
            await _repo.DeleteAsync(accountId);
            await _repo.SaveChangesAsync();
            return Exist;
        }

        public async ValueTask<CustomerAccount?> ExistenceAsync(CustomerAccount? account)
        {
            if (account == null)
                return null;
            return await _repo.ReadAsync(a => a.UserName == account.UserName &&
             a.Password == account.Password);
        }

        public async ValueTask<IEnumerable<CustomerAccount>?> ReadAllAsync()
        {
            return await _repo.ReadAllAsync();
        }

        public async ValueTask<CustomerAccount?> ReadAsync(object accountId)
        {
            return await _repo.ReadAsync(accountId);
        }

        public async ValueTask<CustomerAccount?> UpdateAsync(CustomerAccount account)
        {
            var Exist = await ReadAsync(account.Id);
            if (Exist == null) return null;
            _repo.Update(account);
            await _repo.SaveChangesAsync();
            return account;
        }
    }
}
