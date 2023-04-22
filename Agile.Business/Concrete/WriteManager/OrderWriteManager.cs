using Agile.Business.Abstract.WriteServices;
using Agile.DataAccess.Abstract.ReadDALs;
using Agile.DataAccess.Abstract.WriteDALs;
using Agile.Entities.Concrete;

namespace Agile.Business.Concrete.WriteManager
{
    public class OrderWriteManager : IOrderWriteService
    {
        IOrderWriteDal _orderWriteDal;
        IOrderReadDal _orderReadDal;
        IProductWriteService _productWriteService; 
        public OrderWriteManager(IOrderWriteDal orderWriteDal, IOrderReadDal orderReadDal, IProductWriteService productWriteService)
        {
            _orderWriteDal = orderWriteDal;
            _orderReadDal = orderReadDal;
            _productWriteService = productWriteService;
        }

        public async Task<bool> CreateAsync(int? customerId, int productId, int quantity, DateTime orderDate, DateTime expectedOrderDate)
        {
            try
            {
                if (customerId == null)
                    throw new ArgumentNullException(nameof(customerId));
                await _orderWriteDal.CreateAsync(customerId, productId, quantity, orderDate, expectedOrderDate);
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Order entity, int? id)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));
                else
                {
                    if (await _orderReadDal.GetOrderByIdAsync(id) != null)
                        await _orderWriteDal.DeleteAsync(entity);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(int id, int? customerId, int productId, int quantity, DateTime orderDate, DateTime expectedOrderDate)
        {
            try
            {
                if (customerId == null)
                    throw new ArgumentNullException(nameof(customerId));
                else
                    await _orderWriteDal.UpdateAsync(id, customerId, productId, quantity, orderDate, expectedOrderDate);
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
