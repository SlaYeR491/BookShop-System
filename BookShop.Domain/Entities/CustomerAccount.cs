namespace BookShop.Data
{
    public class CustomerAccount
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public virtual List<CustomerRoom> DiscussionRooms { get; set; }
        public virtual List<Payment> Payments { get; set; }
        public virtual List<CustomerBook> CustomerBooksList { get; set; }
        public virtual List<RoomDetail> Messages { get; set; }
    }
}
