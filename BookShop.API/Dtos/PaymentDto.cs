
using BookShop.Domain.Enums;

namespace BookShop.API.Dtos
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public PaymentStatus Status { get; set; }
        public DateTime Date { get; } = DateTime.Now;
        public List<BookDto> Books { get; set; }
    }
}
