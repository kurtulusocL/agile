using Agile.Core.Entities;

namespace Agile.Core.DataAccess
{
    public interface IEntityWriteRepository<T> where T : class, IEntity, new()
    {
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
    }
}
