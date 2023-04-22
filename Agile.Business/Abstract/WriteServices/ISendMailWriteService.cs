using Agile.Entities.Concrete;

namespace Agile.Business.Abstract.WriteServices
{
    public interface ISendMailWriteService
    {
        Task<bool> CreateAsync(int? customerId, string senderEmail, string recieverEmail, string subject, string mailText);
        Task<bool> DeleteAsync(SendMail entity, int? id);
    }
}
