namespace BookShop.Data
{
    public class Room
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Name { get; set; }
        public virtual List<CustomerRoom> Customers { get; set; }
        public virtual Book Book { get; set; }
        public virtual List<RoomDetail> Details { get; set; }

    }
}
