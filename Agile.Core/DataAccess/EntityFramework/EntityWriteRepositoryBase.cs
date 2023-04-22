using Agile.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Agile.Core.DataAccess.EntityFramework
{
    public class EntityWriteRepositoryBase<TEntity, TContext> : IEntityWriteRepository<TEntity> where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public async Task<bool> AddAsync(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addEntity = context.Entry(entity);
                addEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
            }
            return true;
        }
        public async Task<bool> UpdateAsync(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
            return true;
        }
        public async Task<bool> DeleteAsync(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
            return true;
        }
    }
}
