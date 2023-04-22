using Agile.Entities.Concrete;

namespace Agile.Business.Abstract.ReadServices
{
    public interface ICompanyReadService
    {
        Task<ICollection<Company>> GetAllAsync();
        Task<Company> GetByIdAsync(int? id);
        
    }
}
