using Agile.Business.Abstract.ReadServices;
using Agile.DataAccess.Abstract.ReadDALs;
using Agile.Entities.Concrete;

namespace Agile.Business.Concrete.ReadManager
{
    public class CustomerReadManager : ICustomerReadService
    {
        ICustomerReadDal _customerReadDal;
        public CustomerReadManager(ICustomerReadDal customerReadDal)
        {
            _customerReadDal = customerReadDal;
        }

        public async Task<ICollection<Customer>> GetAllAsync()
        {
            return await _customerReadDal.GetAllCustomersAsync();
        }

        public async Task<Customer> GetByIdAsync(int? id)
        {
            return await _customerReadDal.GetCustomerByIdAsync(id);
        }
    }
}
