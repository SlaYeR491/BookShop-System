using BookShop.Data;
using BookShop.Domain.Interfaces;

namespace BookShop.Application.Services
{
    public class CustomerRoomServices(IRepository<CustomerRoom> _repo,
        ICustomerService customerService,
        IRoomServices roomServices) : ICustomerRoomServices
    {
        public async ValueTask<CustomerRoom?> AddAsync(CustomerRoom entity)
        {
            var Exist = await ExistenceAsync(entity);
            if (Exist != null) return null;
            await _repo.CreateAsync(entity);
            await _repo.SaveChangesAsync();
            return entity;
        }

        public async ValueTask<CustomerRoom?> DeleteAsync(object entityId)
        {
            var Exist = await ReadAsync(entityId);
            if (Exist == null) return null;
            await _repo.DeleteAsync(entityId);
            await _repo.SaveChangesAsync();
            return Exist;
        }

        public async ValueTask<CustomerRoom?> ExistenceAsync(CustomerRoom? entity)
        {
            if (entity == null) return null;
            return await _repo.ReadAsync(a => a.CustomerId == entity.CustomerId &&
            a.RoomId == entity.RoomId);
        }

        public async ValueTask<CustomerRoom?> JoinAsync(CustomerRoom customerRoom)
        {
            var Exist = await ExistenceAsync(customerRoom);
            if (Exist != null) return null;
            var Room = await roomServices.ReadAsync(customerRoom.RoomId);
            var Customer = await customerService.ReadAsync(customerRoom.CustomerId);
            if (Room == null || Customer == null) return null;
            await _repo.CreateAsync(customerRoom);
            await _repo.SaveChangesAsync();
            return customerRoom;
        }

        public async ValueTask<IEnumerable<CustomerRoom>?> ReadAllAsync()
        {
            return await _repo.ReadAllAsync();
        }

        public async ValueTask<IEnumerable<CustomerRoom>?> ReadAllAsync(object CustomerId)
        {
            return await _repo.ReadAllAsync(a => a.CustomerId.Equals(CustomerId));
        }

        public async ValueTask<CustomerRoom?> ReadAsync(object entityId)
        {
            return await ExistenceAsync(entityId as CustomerRoom);
        }

        public async ValueTask<CustomerRoom?> UpdateAsync(CustomerRoom entity)
        {
            var Exist = await ExistenceAsync(entity);
            if (Exist == null) return null;
            _repo.Update(entity);
            await _repo.SaveChangesAsync();
            return entity;
        }
    }
}
