using BookShop.Data;
using BookShop.Domain.Enums;
using BookShop.Domain.Interfaces;

namespace BookShop.Application.Services
{
    public class PaymentServices(IRepository<Payment> _repo,
        IRepository<CustomerBook> _cusbookrepo,
        IRepository<Book> _bookrepo,
        IRepository<PaymentBook> _paybookrepo) : IPaymentServices
    {
        public async ValueTask<PaymentStatus> CheckStatusAsync(int PaymentId)
        {
            try
            {
                var pay = await _repo.ReadAsync(PaymentId);
                if (pay != null)
                    return pay.Status;
                return PaymentStatus.notexist;
            }
            catch (Exception)
            {
                return PaymentStatus.notexist;
            }
        }

        public PaymentStatus ConfirmPayment(int CustomerId)
        {
            try
            {
                var books = _cusbookrepo.ReadAll(a => a.CustomerId == CustomerId);
                if (books == null)
                    return PaymentStatus.notexist;
                foreach (var book in books)
                {
                    var exist = _bookrepo.Read(book.BookId);
                    if (exist == null)
                        return PaymentStatus.notexist;
                    if (exist.Quantity < book.Quantity)
                        return PaymentStatus.notenoughquantity;
                    exist.Quantity -= book.Quantity;
                    _bookrepo.Update(exist);
                    book.Book = exist;
                }
                var pay = new Payment
                {
                    CustomerId = CustomerId,
                    Amount = books.Sum(a => a.Quantity * a.Book.Price),
                    Status = PaymentStatus.hanging
                };
                _repo.Create(pay);
                _bookrepo.SaveChanges();
                foreach (var book in books)
                {
                    _paybookrepo.Create(new PaymentBook
                    {
                        BookId = book.BookId,
                        PaymentId = pay.Id,
                        Qauntity = book.Quantity
                    });
                }
                _paybookrepo.SaveChanges();
                return PaymentStatus.confirmed;
            }
            catch (Exception)
            {
                return PaymentStatus.hanging;
            }
        }
    }
}
