using Agile.Entities.Concrete;

namespace Agile.Business.Abstract.ReadServices
{
    public interface IOrderReadService
    {
        Task<ICollection<Order>> GetAllAsync();
        Task<ICollection<Order>> GetAllOrdersByProductIdAsync(int? productId);
        Task<List<Order>> GetAllOrdersByCustomerIdAsync(int? customerId);
        Task<Order> GetByIdAsync(int? id);
        Order GetCreate(int? id);
    }
}
