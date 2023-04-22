using Agile.Business.Abstract.ReadServices;
using Agile.DataAccess.Abstract.ReadDALs;
using Agile.Entities.Concrete;

namespace Agile.Business.Concrete.ReadManager
{
    public class SendMailReadManager : ISendMailReadService
    {
        ISendMailReadDal _sendMailReadDal;
        public SendMailReadManager(ISendMailReadDal sendMailReadDal)
        {
            _sendMailReadDal = sendMailReadDal;
        }

        public async Task<ICollection<SendMail>> GetAllAsync()
        {
            return await _sendMailReadDal.GetAllSentMailsAsync();
        }

        public async Task<ICollection<SendMail>> GetAllSentMailsByCustomerIdAsync(int? customerId)
        {
            return await _sendMailReadDal.GetAllSentMailsByCustomerIdAsync(customerId);
        }

        public async Task<SendMail> GetByIdAsync(int? id)
        {
            return await _sendMailReadDal.GetSentMailByIdAsync(id);
        }

        public SendMail GetCreate(int? id)
        {
            return _sendMailReadDal.GetCreate(id);
        }

        public async Task<SendMail> GetSentMailAsync(string email)
        {
            return await _sendMailReadDal.GetSentMailAsync(email);
        }
    }
}
