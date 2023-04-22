using Agile.Business.Abstract.WriteServices;
using Agile.DataAccess.Abstract.ReadDALs;
using Agile.DataAccess.Abstract.WriteDALs;
using Agile.Entities.Concrete;

namespace Agile.Business.Concrete.WriteManager
{
    public class ProductWriteManager : IProductWriteService
    {
        IProductWriteDal _productWriteDal;
        IProductReadDal _productReadDal;
        public ProductWriteManager(IProductWriteDal productWriteDal, IProductReadDal productReadDal)
        {
            _productWriteDal = productWriteDal;
            _productReadDal = productReadDal;
        }

        public async Task<bool> CreateAsync(int? companyId, int quantity, string name, string description, decimal price)
        {
            try
            {
                if (companyId == null)
                    throw new ArgumentNullException(nameof(companyId));
                else
                    await _productWriteDal.CreateAsync(companyId, quantity, name, description, price);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> CreateNewQuanity(int id, int quantity)
        {
            return await _productWriteDal.CreateNewQuanity(id, quantity);
        }

        public async Task<bool> DeleteAsync(Product entity, int? id)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));
                else
                {
                    if (await _productReadDal.GetProductByIdAsync(id) != null)
                        await _productWriteDal.DeleteAsync(entity);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(int? companyId, int id, int quantity, string name, string description, decimal price)
        {
            try
            {
                if (companyId == null)
                    throw new ArgumentNullException(nameof(companyId));
                else
                    await _productWriteDal.UpdateAsync(companyId, id, quantity, name, description, price);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
