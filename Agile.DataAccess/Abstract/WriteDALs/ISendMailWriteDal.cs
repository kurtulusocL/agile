using Agile.Core.DataAccess;
using Agile.Entities.Concrete;

namespace Agile.DataAccess.Abstract.WriteDALs
{
    public interface ISendMailWriteDal : IEntityWriteRepository<SendMail>
    {
        Task<bool> CreateAsync(int? customerId, string senderEmail, string recieverEmail, string subject, string mailText);
    }
}
