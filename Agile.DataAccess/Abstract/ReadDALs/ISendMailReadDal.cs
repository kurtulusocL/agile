using Agile.Core.DataAccess;
using Agile.Entities.Concrete;

namespace Agile.DataAccess.Abstract.ReadDALs
{
    public interface ISendMailReadDal : IEntityReadRepository<SendMail>
    {
        Task<List<SendMail>> GetAllSentMailsAsync();
        Task<List<SendMail>> GetAllSentMailsByCustomerIdAsync(int? customerId);
        Task<SendMail> GetSentMailAsync(string email);
        Task<SendMail> GetSentMailByIdAsync(int? id);
        SendMail GetCreate(int? id);
    }
}
