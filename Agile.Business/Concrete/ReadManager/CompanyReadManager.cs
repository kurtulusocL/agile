using Agile.Business.Abstract.ReadServices;
using Agile.DataAccess.Abstract.ReadDALs;
using Agile.Entities.Concrete;

namespace Agile.Business.Concrete.ReadManager
{
    public class CompanyReadManager : ICompanyReadService
    {
        ICompanyReadDal _companyReadDal;
        public CompanyReadManager(ICompanyReadDal companyReadDal)
        {
            _companyReadDal = companyReadDal;
        }

        public async Task<ICollection<Company>> GetAllAsync()
        {
            return await _companyReadDal.GetAllCompaniesAsync();
        }

        public async Task<Company> GetByIdAsync(int? id)
        {
            return await _companyReadDal.GetCompanyByIdAsync(id);
        }
    }
}
