using BookShop.Data;
using BookShop.Domain.Interfaces;

namespace BookShop.Application.Services
{
    public class RoomDetailServices(IRepository<RoomDetail> _repo,
        IRoomServices roomServices,
        ICustomerRoomServices customerRoomServices) : IRoomDetailServices
    {
        public async ValueTask<RoomDetail?> DeleteMessageAsync(object messageId)
        {
            var msg = await _repo.ReadAsync(a => a.Id.Equals(messageId));
            if (msg == null) return null;
            await _repo.DeleteAsync(msg.Id);
            await _repo.SaveChangesAsync();
            return msg;
        }

        public async ValueTask<IEnumerable<RoomDetail>?> LoadChatAsync(object roomId)
        {
            return await _repo.ReadAllAsync(a => a.RoomId.Equals(roomId));
        }

        public async ValueTask<RoomDetail?> SendMessageAsync(RoomDetail details)
        {
            if (await _repo.ReadAsync(a => a.CustomerId == details.CustomerId && a.RoomId == details.RoomId) != null
                || await roomServices.ReadAsync(details.RoomId) == null
                || await customerRoomServices.ExistenceAsync(new CustomerRoom { RoomId = details.RoomId, CustomerId = details.CustomerId }) == null
                )
                return null;
            details.SendTime = DateTime.UtcNow;
            await _repo.CreateAsync(details);
            await _repo.SaveChangesAsync();
            return details;
        }

        public async ValueTask<RoomDetail?> UpdateMessageAsync(RoomDetail details)
        {
            if (await _repo.ReadAsync(a => a.CustomerId == details.CustomerId && a.RoomId == details.RoomId) == null
                || await _repo.ReadAsync(a => a.Id == details.Id) == null)
                return null;
            _repo.Update(details);
            await _repo.SaveChangesAsync();
            return details;
        }
    }
}
