using Agile.Business.Abstract.ReadServices;
using Agile.DataAccess.Abstract.ReadDALs;
using Agile.Entities.Concrete;

namespace Agile.Business.Concrete.ReadManager
{
    public class ProductReadManager : IProductReadService
    {
        IProductReadDal _productReadDal;
        public ProductReadManager(IProductReadDal productReadDal)
        {
            _productReadDal = productReadDal;
        }

        public async Task<ICollection<Product>> GetAllAsync()
        {
            return await _productReadDal.GetAllProductsAsync();
        }

        public async Task<ICollection<Product>> GetAllProductsByCompanyIdAsync(int? companyId)
        {
            return await _productReadDal.GetAllProductsByCompanyIdAsync(companyId);
        }

        public async Task<List<Product>> GetAllProductsForAddOrderAsync()
        {
            return await _productReadDal.GetAllProductsForAddOrderAsync();
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            return await _productReadDal.GetProductByIdAsync(id);
        }

        public Product GetCreate(int? id)
        {
            return _productReadDal.GetCreate(id);
        }

        public Product GetProductNewQuantity(int id, int quantity)
        {
            return _productReadDal.GetProductNewQuantity(id, quantity);
        }
    }
}
