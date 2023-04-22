using Agile.Core.DataAccess;
using Agile.Entities.Concrete;

namespace Agile.DataAccess.Abstract.ReadDALs
{
    public interface IProductReadDal : IEntityReadRepository<Product>
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<List<Product>> GetAllProductsForAddOrderAsync();
        Task<List<Product>> GetAllProductsByCompanyIdAsync(int? companyId);
        Task<Product> GetProductByIdAsync(int? id);
        Product GetCreate(int? id);
        Product GetProductNewQuantity(int id, int quantity);
    }
}
