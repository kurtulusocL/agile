using Agile.Entities.Concrete;

namespace Agile.Business.Abstract.ReadServices
{
    public interface ISendMailReadService
    {
        Task<ICollection<SendMail>> GetAllAsync();
        Task<ICollection<SendMail>> GetAllSentMailsByCustomerIdAsync(int? customerId);
        Task<SendMail> GetSentMailAsync(string email);
        Task<SendMail> GetByIdAsync(int? id);
        SendMail GetCreate(int? id);
    }
}
