using BookShop.Data;

namespace BookShop.Domain.Interfaces
{
    public interface IRoomServices:ICRUD<Room>
    {
        public ValueTask<Room?> SearchAsync(string BookTitle);
    }
    

}
