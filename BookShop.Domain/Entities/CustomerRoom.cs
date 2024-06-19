namespace BookShop.Data
{
    public class CustomerRoom
    {
        public int RoomId { get; set; }
        public int CustomerId { get; set; }
        public virtual CustomerAccount Account { get; set; }
        public virtual Room Room { get; set; }
    }
}
