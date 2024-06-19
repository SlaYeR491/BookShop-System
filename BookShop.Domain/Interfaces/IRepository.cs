using System.Linq.Expressions;

namespace BookShop.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public ValueTask<TEntity?> CreateAsync(TEntity entity);
        public TEntity? Create(TEntity entity);
        public void Update(TEntity entity);
        public ValueTask<TEntity?> DeleteAsync(object id);
        public ValueTask<TEntity?> DeleteAsync(Expression<Func<TEntity, bool>> criteria);
        public ValueTask<TEntity?> ReadAsync(object id);
        public TEntity? Read(object id);
        public ValueTask<TEntity?> ReadAsync(Expression<Func<TEntity, bool>> expression);
        public ValueTask<IEnumerable<TEntity>?> ReadAllAsync();
        public ValueTask<IEnumerable<TEntity>?> ReadAllAsync(Expression<Func<TEntity, bool>> expression);
        public IEnumerable<TEntity>? ReadAll(Expression<Func<TEntity, bool>> expression);
        public ValueTask SaveChangesAsync();
        public void SaveChanges();
    }
}
