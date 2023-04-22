using Agile.Entities.Concrete;

namespace Agile.Business.Abstract.ReadServices
{
    public interface IProductReadService
    {
        Task<ICollection<Product>> GetAllAsync();
        Task<List<Product>> GetAllProductsForAddOrderAsync();
        Task<ICollection<Product>> GetAllProductsByCompanyIdAsync(int? companyId);
        Task<Product> GetByIdAsync(int? id);
        Product GetCreate(int? id);
        Product GetProductNewQuantity(int id,int quantity);
    }
}
