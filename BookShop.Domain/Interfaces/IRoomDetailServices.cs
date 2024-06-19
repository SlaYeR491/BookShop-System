using BookShop.Data;

namespace BookShop.Domain.Interfaces
{
    public interface IRoomDetailServices 
    {
        public ValueTask<IEnumerable<RoomDetail>?> LoadChatAsync(object roomId);
        public ValueTask<RoomDetail?> SendMessageAsync(RoomDetail details);
        public ValueTask<RoomDetail?> UpdateMessageAsync(RoomDetail details);
        public ValueTask<RoomDetail?> DeleteMessageAsync(object messageId);
    }
}
