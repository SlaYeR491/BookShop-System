using BookShop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookShop.Infrastructure.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> Entity;
        private readonly AppDbContext dbContext;

        public Repository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            Entity = dbContext.Set<TEntity>();
        }

        public TEntity? Create(TEntity entity)
        {
            Entity.Add(entity);
            return entity;
        }

        public async ValueTask<TEntity?> CreateAsync(TEntity entity)
        {
            try
            {
                await Entity.AddAsync(entity);
                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async ValueTask<TEntity?> DeleteAsync(object id)
        {
            try
            {
                var exist = await Entity.FindAsync(id);
                Entity.Remove(exist);
                return exist;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async ValueTask<TEntity?> DeleteAsync(Expression<Func<TEntity, bool>> criteria)
        {
            try
            {
                var exist = await Entity.FirstOrDefaultAsync(criteria);
                Entity.Remove(exist);
                return exist;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public TEntity? Read(object id)
        {
            return Entity.Find(id);
        }

        public IEnumerable<TEntity>? ReadAll(Expression<Func<TEntity, bool>> criteria)
        {
            return Entity.Where(criteria).ToList();
        }

        public async ValueTask<IEnumerable<TEntity>?> ReadAllAsync()
        {
            return await Entity.ToListAsync();
        }

        public async ValueTask<IEnumerable<TEntity>?> ReadAllAsync(Expression<Func<TEntity, bool>> criteria)
        {
            return await Entity.Where(criteria).ToListAsync();
        }

        public async ValueTask<TEntity?> ReadAsync(object id)
        {
            return await Entity.FindAsync(id);
        }

        public async ValueTask<TEntity?> ReadAsync(Expression<Func<TEntity, bool>> criteria)
        {
            return await Entity.FirstOrDefaultAsync(criteria);
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        public async ValueTask SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            Entity.Update(entity);
        }
    }
}
