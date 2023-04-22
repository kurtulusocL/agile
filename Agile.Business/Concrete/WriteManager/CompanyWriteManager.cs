using Agile.Business.Abstract.WriteServices;
using Agile.DataAccess.Abstract.ReadDALs;
using Agile.DataAccess.Abstract.WriteDALs;
using Agile.Entities.Concrete;

namespace Agile.Business.Concrete.WriteManager
{
    public class CompanyWriteManager : ICompanyWriteService
    {
        ICompanyWriteDal _companyWriteDal;
        ICompanyReadDal _companyReadDal;
        public CompanyWriteManager(ICompanyWriteDal companyWriteDal, ICompanyReadDal companyReadDal)
        {
            _companyWriteDal = companyWriteDal;
            _companyReadDal = companyReadDal;

        }

        public async Task<bool> CreateAsync(Company entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));
                else
                    await _companyWriteDal.AddAsync(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Company entity, int? id)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));
                else
                {
                    if (await _companyReadDal.GetCompanyByIdAsync(id) != null)
                        await _companyWriteDal.DeleteAsync(entity);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Company entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));
                else
                    await _companyWriteDal.UpdateAsync(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
