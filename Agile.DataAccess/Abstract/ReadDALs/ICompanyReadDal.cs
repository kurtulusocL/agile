using Agile.Core.DataAccess;
using Agile.Entities.Concrete;

namespace Agile.DataAccess.Abstract.ReadDALs
{
    public interface ICompanyReadDal : IEntityReadRepository<Company>
    {
        Task<List<Company>> GetAllCompaniesAsync();
        Task<Company> GetCompanyByIdAsync(int? id);
    }
}
