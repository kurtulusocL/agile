using Agile.Entities.Concrete;

namespace Agile.Business.Abstract.WriteServices
{
    public interface IOrderWriteService
    {
        Task<bool> CreateAsync(int? customerId, int productId, int quantity, DateTime orderDate, DateTime expectedOrderDate);
        Task<bool> UpdateAsync(int id, int? customerId, int productId, int quantity, DateTime orderDate, DateTime expectedOrderDate);
        Task<bool> DeleteAsync(Order entity, int? id);
    }
}
