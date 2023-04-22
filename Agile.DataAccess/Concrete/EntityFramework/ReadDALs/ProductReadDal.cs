using Agile.Core.DataAccess.EntityFramework;
using Agile.DataAccess.Abstract.ReadDALs;
using Agile.DataAccess.Concrete.EntityFramework.Context;
using Agile.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Agile.DataAccess.Concrete.EntityFramework.ReadDALs
{
    public class ProductReadDal : EntityReadRepositoryBase<Product, ApplicationDbContext>, IProductReadDal
    {
        public async Task<List<Product>> GetAllProductsAsync()
        {
            using (ApplicationDbContext context = new())
            {
                return await context.Set<Product>().Include("Company").Include("Orders").OrderByDescending(i => i.Orders.Count()).ToListAsync();
            }
        }

        public async Task<List<Product>> GetAllProductsByCompanyIdAsync(int? companyId)
        {
            using (ApplicationDbContext context = new())
            {
                return await context.Set<Product>().Include("Company").Include("Orders").Where(i => i.CompanyId == companyId).OrderByDescending(i => i.Orders.Count()).ToListAsync();
            }
        }

        public async Task<Product> GetProductByIdAsync(int? id)
        {
            using (ApplicationDbContext context = new())
            {
                return await context.Set<Product>().Include("Company").Include("Orders").Where(i => i.Id == id).FirstOrDefaultAsync();
            }
        }
        public Product GetCreate(int? id)
        {
            Product model = new Product
            {
                CompanyId = id,
            };
            return model;
        }

        public Product GetProductNewQuantity(int id, int quantity)
        {
            using (ApplicationDbContext context = new())
            {
                var model = new Product()
                {
                    Id = id,
                    Quantity = quantity
                };
                return model;
            }
        }

        public async Task<List<Product>> GetAllProductsForAddOrderAsync()
        {
            using (ApplicationDbContext context = new())
            {
                return await context.Set<Product>().Include("Company").Include("Orders").Where(i => i.Quantity > 0).OrderByDescending(i => i.Orders.Count()).ToListAsync();
            }
        }
    }
}
