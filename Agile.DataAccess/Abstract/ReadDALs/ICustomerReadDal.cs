using Agile.Core.DataAccess;
using Agile.Entities.Concrete;

namespace Agile.DataAccess.Abstract.ReadDALs
{
    public interface ICustomerReadDal : IEntityReadRepository<Customer>
    {
        Task<List<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int? id);
    }
}
