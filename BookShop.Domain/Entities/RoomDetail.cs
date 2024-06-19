namespace BookShop.Data
{
    public class RoomDetail
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int CustomerId { get; set; }
        public string Message { get; set; }
        public DateTime SendTime { get; set; }=DateTime.Now;
        public virtual CustomerAccount Customer { get; set; }
        public virtual Room Room { get; set; }
    }
}
