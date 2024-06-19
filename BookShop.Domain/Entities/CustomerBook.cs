namespace BookShop.Data
{
    public class CustomerBook
    {
        public int CustomerId { set; get; }
        public int BookId { set; get; }
        public int Quantity { set; get; }
        public virtual CustomerAccount Account { set; get; }
        public virtual Book Book { set; get; }
    }
}
