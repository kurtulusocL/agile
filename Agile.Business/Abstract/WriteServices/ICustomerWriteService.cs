using Agile.Entities.Concrete;

namespace Agile.Business.Abstract.WriteServices
{
    public interface ICustomerWriteService
    {
        Task<bool> CreateAsync(Customer entity);
        Task<bool> UpdateAsync(Customer entity);
        Task<bool> DeleteAsync(Customer entity, int? id);
    }
}
