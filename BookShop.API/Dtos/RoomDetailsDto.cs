namespace BookShop.API.Dtos
{
    public class RoomDetailsDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int RoomId { get; set; }
        public string Message {  get; set; }
        public DateTime SendTime { get; set; }
    }
}
