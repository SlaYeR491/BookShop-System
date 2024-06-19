namespace BookShop.Data
{
    public class Book
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public virtual PaymentBook Payment { get; set; }
        public virtual Room DiscussionRoom { get; set; }
        public virtual List<CustomerBook> CustomerBooksList { get; set; }
    }
}
