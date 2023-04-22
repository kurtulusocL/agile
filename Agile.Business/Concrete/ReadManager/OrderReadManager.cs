using Agile.Business.Abstract.ReadServices;
using Agile.DataAccess.Abstract.ReadDALs;
using Agile.Entities.Concrete;

namespace Agile.Business.Concrete.ReadManager
{
    public class OrderReadManager : IOrderReadService
    {
        IOrderReadDal _orderReadDal;
        public OrderReadManager(IOrderReadDal orderReadDal)
        {
            _orderReadDal = orderReadDal;
        }

        public async Task<ICollection<Order>> GetAllAsync()
        {
            return await _orderReadDal.GetAllOrdersAsync();
        }

        public async Task<List<Order>> GetAllOrdersByCustomerIdAsync(int? customerId)
        {
            return await _orderReadDal.GetAllOrdersByCustomerIdAsync(customerId);
        }

        public async Task<ICollection<Order>> GetAllOrdersByProductIdAsync(int? productId)
        {
            return await _orderReadDal.GetAllOrdersByProductIdAsync(productId);
        }

        public async Task<Order> GetByIdAsync(int? id)
        {
            return await _orderReadDal.GetOrderByIdAsync(id);
        }

        public Order GetCreate(int? id)
        {
            return _orderReadDal.GetCreate(id);
        }
    }
}
