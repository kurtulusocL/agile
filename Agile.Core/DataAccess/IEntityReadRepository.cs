using Agile.Core.Entities;
using System.Linq.Expressions;

namespace Agile.Core.DataAccess
{
    public interface IEntityReadRepository<T> where T : class, IEntity, new()
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
    }
}
