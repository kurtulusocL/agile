using Agile.Core.DataAccess.EntityFramework;
using Agile.DataAccess.Abstract.ReadDALs;
using Agile.DataAccess.Concrete.EntityFramework.Context;
using Agile.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Agile.DataAccess.Concrete.EntityFramework.ReadDALs
{
    public class CustomerReadDal : EntityReadRepositoryBase<Customer, ApplicationDbContext>, ICustomerReadDal
    {
        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            using (ApplicationDbContext context = new())
            {
                return await context.Set<Customer>().Include("Orders").Include("SendMails").OrderByDescending(i => i.CreatedDate).ToListAsync();
            }
        }

        public async Task<Customer> GetCustomerByIdAsync(int? id)
        {
            using (ApplicationDbContext context = new())
            {
                return await context.Set<Customer>().Include("Orders").Include("SendMails").Where(i => i.Id == id).FirstOrDefaultAsync();
            }
        }
    }
}
