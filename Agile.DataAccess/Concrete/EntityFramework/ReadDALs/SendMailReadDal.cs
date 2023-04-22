using Agile.Core.DataAccess.EntityFramework;
using Agile.DataAccess.Abstract.ReadDALs;
using Agile.DataAccess.Concrete.EntityFramework.Context;
using Agile.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Agile.DataAccess.Concrete.EntityFramework.ReadDALs
{
    public class SendMailReadDal : EntityReadRepositoryBase<SendMail, ApplicationDbContext>, ISendMailReadDal
    {
        public async Task<List<SendMail>> GetAllSentMailsAsync()
        {
            using (ApplicationDbContext context = new())
            {
                return await context.Set<SendMail>().Include("Customer").OrderByDescending(i => i.CreatedDate).ToListAsync();
            }
        }

        public async Task<List<SendMail>> GetAllSentMailsByCustomerIdAsync(int? customerId)
        {
            using (ApplicationDbContext context = new())
            {
                return await context.Set<SendMail>().Include("Customer").Where(i => i.CustomerId == customerId).OrderByDescending(i => i.CreatedDate).ToListAsync();
            }
        }

        public SendMail GetCreate(int? id)
        {
            SendMail model = new SendMail
            {
                CustomerId = id
            };
            return model;
        }

        public async Task<SendMail> GetSentMailAsync(string email)
        {
            using (ApplicationDbContext context = new())
            {
                return await context.Set<SendMail>().Include("Customer").Where(i => i.Customer.Email == email).FirstOrDefaultAsync();
            }
        }

        public async Task<SendMail> GetSentMailByIdAsync(int? id)
        {
            using (ApplicationDbContext context = new())
            {
                return await context.Set<SendMail>().Include("Customer").Where(i => i.Id == id).FirstOrDefaultAsync();
            }
        }
    }
}
