namespace BookShop.Data
{
    public class PaymentBook
    {
        public int PaymentId { get; set; }
        public int BookId { get; set; }
        public int Qauntity { get; set; }
        public virtual Book Book { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
