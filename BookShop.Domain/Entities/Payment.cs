using BookShop.Domain.Enums;

namespace BookShop.Data
{
    public class Payment
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public PaymentStatus Status { get; set; }
        public DateTime Date { get; } = DateTime.Now;
        public virtual CustomerAccount Customer { get; set; }
        public virtual List<PaymentBook> books { get; set; }
    }
    
}
