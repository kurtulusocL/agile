using Agile.Entities.Concrete;

namespace Agile.Business.Abstract.WriteServices
{
    public interface ICompanyWriteService
    {
        Task<bool> CreateAsync(Company entity);
        Task<bool> UpdateAsync(Company entity);
        Task<bool> DeleteAsync(Company entity, int? id);
    }
}
