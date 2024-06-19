using System.Linq.Expressions;

namespace BookShop.Domain.Interfaces
{
    public interface ICRUD<TEntity> where TEntity : class
    {
        public ValueTask<TEntity?> ExistenceAsync(TEntity? entity);
        public ValueTask<TEntity?> AddAsync(TEntity entity);
        public ValueTask<TEntity?> UpdateAsync(TEntity entity);
        public ValueTask<TEntity?> DeleteAsync(object entityId);
        public ValueTask<TEntity?> ReadAsync(object entityId);
        public ValueTask<IEnumerable<TEntity>?> ReadAllAsync();
    }
}
