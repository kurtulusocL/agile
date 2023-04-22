using Agile.Core.DataAccess.EntityFramework;
using Agile.DataAccess.Abstract.ReadDALs;
using Agile.DataAccess.Abstract.WriteDALs;
using Agile.DataAccess.Concrete.EntityFramework.Context;
using Agile.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Agile.DataAccess.Concrete.EntityFramework.WriteDALs
{
    public class OrderWriteDal : EntityWriteRepositoryBase<Order, ApplicationDbContext>, IOrderWriteDal
    {
        IProductReadDal _productReadDal;
        public OrderWriteDal(IProductReadDal productReadDal)
        {
            _productReadDal = productReadDal;
        }
        public async Task<bool> CreateAsync(int? customerId, int productId, int quantity, DateTime orderDate, DateTime expectedOrderDate)
        {
            using (ApplicationDbContext context = new())
            {
                var model = new Order
                {
                    CustomerId = customerId,
                    ProductId = productId,
                    Quantity = quantity,
                    OrderDate = orderDate,
                    ExpectedOrderDate = expectedOrderDate
                };
                if (model.ProductId != null)
                {
                    var productQuantity = await _productReadDal.GetProductByIdAsync(model.ProductId);
                    if (model.Quantity <= productQuantity.Quantity)
                    {
                        await context.Orders.AddAsync(model);
                        context.Entry(model).State = EntityState.Added;
                        var result = await context.SaveChangesAsync();
                        if (result > 0)
                        {
                            return true;
                        }
                        return false;
                    }
                }
                return false;
            }
        }

        public async Task<bool> UpdateAsync(int id, int? customerId, int productId, int quantity, DateTime orderDate, DateTime expectedOrderDate)
        {
            using (ApplicationDbContext context = new())
            {
                var model = new Order
                {
                    Id = id,
                    CustomerId = customerId,
                    ProductId = productId,
                    Quantity = quantity,
                    OrderDate = orderDate,
                    ExpectedOrderDate = expectedOrderDate
                };
                if (model.ProductId != null)
                {
                    var productQuantity = await _productReadDal.GetProductByIdAsync(model.ProductId);
                    if (model.Quantity <= productQuantity.Quantity)
                    {
                        context.Orders.Update(model);
                        context.Entry(model).State = EntityState.Modified;
                        var result = await context.SaveChangesAsync();
                        if (result > 0)
                        {
                            return true;
                        }
                        return false;
                    }
                }
                return false;
            }
        }
    }
}
