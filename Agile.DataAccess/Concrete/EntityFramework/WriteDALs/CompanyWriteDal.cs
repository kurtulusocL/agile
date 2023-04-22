using Agile.Core.DataAccess.EntityFramework;
using Agile.DataAccess.Abstract.WriteDALs;
using Agile.DataAccess.Concrete.EntityFramework.Context;
using Agile.Entities.Concrete;

namespace Agile.DataAccess.Concrete.EntityFramework.WriteDALs
{
    public class CompanyWriteDal : EntityWriteRepositoryBase<Company, ApplicationDbContext>, ICompanyWriteDal
    {
    }
}
