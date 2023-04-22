using Agile.Business.Abstract.WriteServices;
using Agile.DataAccess.Abstract.ReadDALs;
using Agile.DataAccess.Abstract.WriteDALs;
using Agile.Entities.Concrete;

namespace Agile.Business.Concrete.WriteManager
{
    public class CustomerWriteManager : ICustomerWriteService
    {
        ICustomerWriteDal _customerWriteDal;
        ICustomerReadDal _customerReadDal;
        public CustomerWriteManager(ICustomerWriteDal customerWriteDal, ICustomerReadDal customerReadDal)
        {
            _customerWriteDal = customerWriteDal;
            _customerReadDal = customerReadDal;
        }

        public async Task<bool> CreateAsync(Customer entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));
                else
                    await _customerWriteDal.AddAsync(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Customer entity, int? id)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));
                else
                {
                    if (await _customerReadDal.GetCustomerByIdAsync(id) != null)
                        await _customerWriteDal.DeleteAsync(entity);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Customer entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));
                else
                    await _customerWriteDal.UpdateAsync(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
