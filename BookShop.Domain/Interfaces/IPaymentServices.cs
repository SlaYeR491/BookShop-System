using BookShop.Data;
using BookShop.Domain.Enums;

namespace BookShop.Domain.Interfaces
{
    public interface IPaymentServices
    {
        public PaymentStatus ConfirmPayment(int CustomerId);
        public ValueTask<PaymentStatus> CheckStatusAsync(int PaymentId);
    }
}
