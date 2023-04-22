using Agile.Core.DataAccess.EntityFramework;
using Agile.DataAccess.Abstract.ReadDALs;
using Agile.DataAccess.Concrete.EntityFramework.Context;
using Agile.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Agile.DataAccess.Concrete.EntityFramework.ReadDALs
{
    public class OrderReadDal : EntityReadRepositoryBase<Order, ApplicationDbContext>, IOrderReadDal
    {
        public async Task<List<Order>> GetAllOrdersAsync()
        {
            using (ApplicationDbContext context = new())
            {
                return await context.Set<Order>().Include("Product").Include("Customer").OrderByDescending(i => i.OrderDate).ToListAsync();
            }
        }

        public async Task<List<Order>> GetAllOrdersByCustomerIdAsync(int? customerId)
        {
            using (ApplicationDbContext context = new())
            {
                return await context.Set<Order>().Include("Product").Include("Customer").Where(i => i.CustomerId == customerId).OrderByDescending(i => i.OrderDate).ToListAsync();
            }
        }

        public async Task<List<Order>> GetAllOrdersByProductIdAsync(int? productId)
        {
            using (ApplicationDbContext context = new())
            {
                return await context.Set<Order>().Include("Product").Include("Customer").Where(i => i.ProductId == productId).OrderByDescending(i => i.OrderDate).ToListAsync();
            }
        }

        public Order GetCreate(int? id)
        {
            Order model = new Order
            {
                CustomerId = id,
            };
            return model;
        }

        public async Task<Order> GetOrderByIdAsync(int? id)
        {
            using (ApplicationDbContext context = new())
            {
                return await context.Set<Order>().Include("Product").Include("Customer").Where(i => i.Id == id).FirstOrDefaultAsync();
            }
        }

        public Order ReadQuantity(int quantity)
        {
            using (ApplicationDbContext context = new())
            {
                return context.Set<Order>().Find(quantity);
            }
        }
    }
}
