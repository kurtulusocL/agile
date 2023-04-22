using Agile.Core.DataAccess.EntityFramework;
using Agile.DataAccess.Abstract.ReadDALs;
using Agile.DataAccess.Abstract.WriteDALs;
using Agile.DataAccess.Concrete.EntityFramework.Context;
using Agile.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Agile.DataAccess.Concrete.EntityFramework.WriteDALs
{
    public class ProductWriteDal : EntityWriteRepositoryBase<Product, ApplicationDbContext>, IProductWriteDal
    {
        IProductReadDal _productReadDal;
        public ProductWriteDal(IProductReadDal productReadDal)
        {
            _productReadDal = productReadDal;
        }
        public async Task<bool> CreateAsync(int? companyId, int quantity, string name, string description, decimal price)
        {
            using (ApplicationDbContext context = new())
            {
                var model = new Product
                {
                    CompanyId = companyId,
                    Name = name,
                    Quantity = quantity,
                    Description = description,
                    Price = price
                };
                await context.Products.AddAsync(model);
                context.Entry(model).State = EntityState.Added;
                var result = await context.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public async Task<bool> CreateNewQuanity(int id, int quantity)
        {
            var productQuantity = await _productReadDal.GetProductByIdAsync(id);
            var newQuantity = productQuantity.Quantity - quantity;

            using (ApplicationDbContext context = new())
            {
                Product model = new Product()
                {
                    Id = id
                };
                var updatedQuantity = await _productReadDal.GetProductByIdAsync(model.Id);
                updatedQuantity.Quantity = newQuantity;

                context.Products.Update(updatedQuantity);
                context.Entry(updatedQuantity).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> UpdateAsync(int? companyId, int id, int quantity, string name, string description, decimal price)
        {
            using (ApplicationDbContext context = new())
            {
                var model = new Product
                {
                    Id = id,
                    CompanyId = companyId,
                    Name = name,
                    Quantity = quantity,
                    Description = description,
                    Price = price
                };
                context.Products.Update(model);
                context.Entry(model).State = EntityState.Modified;
                var result = await context.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
