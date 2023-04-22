using Agile.Business.Abstract.WriteServices;
using Agile.DataAccess.Abstract.ReadDALs;
using Agile.DataAccess.Abstract.WriteDALs;
using Agile.Entities.Concrete;

namespace Agile.Business.Concrete.WriteManager
{
    public class SendMailWriteManager : ISendMailWriteService
    {
        ISendMailWriteDal _sendMailWriteDal;
        ISendMailReadDal _sendMailReadDal;
        public SendMailWriteManager(ISendMailWriteDal sendMailWriteDal, ISendMailReadDal sendMailReadDal)
        {
            _sendMailWriteDal = sendMailWriteDal;
            _sendMailReadDal = sendMailReadDal;
        }

        public async Task<bool> CreateAsync(int? customerId, string senderEmail, string recieverEmail, string subject, string mailText)
        {
            try
            {
                if (customerId == null)
                    throw new ArgumentNullException(nameof(customerId));
                else
                    await _sendMailWriteDal.CreateAsync(customerId, senderEmail, recieverEmail, subject, mailText);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(SendMail entity, int? id)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));
                else
                {
                    if (await _sendMailReadDal.GetSentMailByIdAsync(id) != null)
                        await _sendMailWriteDal.DeleteAsync(entity);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
