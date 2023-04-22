using Agile.Entities.Concrete;

namespace Agile.Business.Abstract.ReadServices
{
    public interface ICustomerReadService
    {
        Task<ICollection<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(int? id);

    }
}
