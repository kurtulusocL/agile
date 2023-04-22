using Agile.Core.DataAccess.EntityFramework;
using Agile.DataAccess.Abstract.ReadDALs;
using Agile.DataAccess.Concrete.EntityFramework.Context;
using Agile.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Agile.DataAccess.Concrete.EntityFramework.ReadDALs
{
    public class CompanyReadDal : EntityReadRepositoryBase<Company, ApplicationDbContext>, ICompanyReadDal
    {
        public async Task<List<Company>> GetAllCompaniesAsync()
        {
            using (ApplicationDbContext context = new())
            {
                return await context.Set<Company>().Include("Products").OrderByDescending(i => i.Products.Count()).ToListAsync();
            }
        }

        public async Task<Company> GetCompanyByIdAsync(int? id)
        {
            using (ApplicationDbContext context = new())
            {
                return await context.Set<Company>().Include("Products").Where(i => i.Id == id).FirstOrDefaultAsync();
            }
        }
    }
}
