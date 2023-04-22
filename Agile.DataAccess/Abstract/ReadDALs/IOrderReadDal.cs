using Agile.Core.DataAccess;
using Agile.Entities.Concrete;

namespace Agile.DataAccess.Abstract.ReadDALs
{
    public interface IOrderReadDal : IEntityReadRepository<Order>
    {
        Task<List<Order>> GetAllOrdersAsync();
        Task<List<Order>> GetAllOrdersByProductIdAsync(int? productId);
        Task<List<Order>> GetAllOrdersByCustomerIdAsync(int? customerId);
        Task<Order> GetOrderByIdAsync(int? id);
        Order GetCreate(int? id);
        Order ReadQuantity(int quantity);
    }
}
