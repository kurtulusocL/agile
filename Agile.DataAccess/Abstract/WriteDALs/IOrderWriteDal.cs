using Agile.Core.DataAccess;
using Agile.Entities.Concrete;

namespace Agile.DataAccess.Abstract.WriteDALs
{
    public interface IOrderWriteDal : IEntityWriteRepository<Order>
    {
        Task<bool> CreateAsync(int? customerId, int productId, int quantity, DateTime orderDate, DateTime expectedOrderDate);
        Task<bool> UpdateAsync(int id, int? customerId, int productId, int quantity, DateTime orderDate, DateTime expectedOrderDate);
    }
}
