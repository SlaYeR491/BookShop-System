using BookShop.Data;
using BookShop.Domain.Interfaces;

namespace BookShop.Application.Services
{
    public class RoomServices(IRepository<Room> _repo,
        IBookServices bookServices) : IRoomServices
    {
        public async ValueTask<Room?> AddAsync(Room entity)
        {
            var Exist = await _repo.ReadAsync(a => a.Name == entity.Name);
            if (Exist != null)
                return null;
            if (await bookServices.ReadAsync(entity.BookId) == null)
                return null;
            await _repo.CreateAsync(entity);
            await _repo.SaveChangesAsync();
            return entity;
        }

        public async ValueTask<Room?> DeleteAsync(object entityId)
        {
            var Exist = await ReadAsync(entityId);
            if (Exist == null) return null;
            await _repo.DeleteAsync(entityId);
            await _repo.SaveChangesAsync();
            return Exist;
        }

        public async ValueTask<Room?> ExistenceAsync(Room? entity)
        {
            if (entity == null) return null;
            return await _repo.ReadAsync(entity.Id);
        }
        public async ValueTask<IEnumerable<Room>?> ReadAllAsync()
        {
            return await _repo.ReadAllAsync();
        }

        public async ValueTask<Room?> ReadAsync(object entityId)
        {
            return await _repo.ReadAsync(entityId);
        }

        public async ValueTask<Room?> SearchAsync(string roomName)
        {
            return await _repo.ReadAsync(a => a.Name.ToLower() == roomName.ToLower());
        }

        public async ValueTask<Room?> UpdateAsync(Room entity)
        {
            var Exist = await _repo.ReadAsync(a => a.Name == entity.Name);
            if (Exist == null) return null;
            _repo.Update(entity);
            await _repo.SaveChangesAsync();
            return entity;
        }
    }
}
