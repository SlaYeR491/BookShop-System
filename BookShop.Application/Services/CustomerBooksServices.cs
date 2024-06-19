using BookShop.Data;
using BookShop.Domain.Interfaces;

namespace BookShop.Application.Services
{
    public class CustomerBooksServices(IRepository<CustomerBook> _repo,
        IBookServices bookServices, ICustomerService customerService) : ICustomerBooksServices
    {
        public async ValueTask<CustomerBook?> AddAsync(CustomerBook book)
        {
            if (await bookServices.ReadAsync(book.BookId) == null ||
                await customerService.ReadAsync(book.CustomerId) == null ||
                book.Quantity == 0)
                return null;
            var Exist = await ExistenceAsync(book);
            if (Exist != null)
                return null;
            await _repo.CreateAsync(book);
            await _repo.SaveChangesAsync();
            return book;
        }

        public async ValueTask<CustomerBook?> DeleteAsync(object entity)
        {
            var book = entity as CustomerBook;
            if (book == null)
                return null;
            var Exist = await _repo.ReadAsync(a => a.CustomerId == book.CustomerId &&
            a.BookId == book.BookId);
            if (Exist == null || book.Quantity == 0)
                return null;
            if (book.Quantity < Exist.Quantity)
            {
                book.Quantity = Exist.Quantity - book.Quantity;
                _repo.Update(book);
            }
            else
                await _repo.DeleteAsync(a=>a.CustomerId==book.CustomerId&&a.BookId==book.BookId);
            await _repo.SaveChangesAsync();
            return book;
        }

        public async ValueTask<CustomerBook?> ExistenceAsync(CustomerBook? book)
        {
            if (book == null)
                return null;
            return await _repo.ReadAsync(a => a.CustomerId == book.CustomerId && a.BookId == book.BookId);
        }

        public async ValueTask<IEnumerable<CustomerBook>?> ReadAllAsync()
        {
            return await _repo.ReadAllAsync();
        }

        public async ValueTask<IEnumerable<CustomerBook>?> ReadAllAsync(int customerId)
        {
            return await _repo.ReadAllAsync(a => a.CustomerId == customerId);
        }

        public async ValueTask<CustomerBook?> ReadAsync(object bookId)
        {
            return await ExistenceAsync(bookId as CustomerBook);
        }

        public async ValueTask<CustomerBook?> UpdateAsync(CustomerBook book)
        {
            if (await ExistenceAsync(book) == null)
                return null;
            _repo.Update(book);
            await _repo.SaveChangesAsync();
            return book;
        }
    }
}
