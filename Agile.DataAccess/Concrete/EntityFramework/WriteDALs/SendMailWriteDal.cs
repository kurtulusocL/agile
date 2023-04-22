using Agile.Core.DataAccess.EntityFramework;
using Agile.DataAccess.Abstract.WriteDALs;
using Agile.DataAccess.Concrete.EntityFramework.Context;
using Agile.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;

namespace Agile.DataAccess.Concrete.EntityFramework.WriteDALs
{
    public class SendMailWriteDal : EntityWriteRepositoryBase<SendMail, ApplicationDbContext>, ISendMailWriteDal
    {
        public async Task<bool> CreateAsync(int? customerId, string senderEmail, string recieverEmail, string subject, string mailText)
        {
            using (ApplicationDbContext context = new())
            {
                var model = new SendMail
                {
                    CustomerId = customerId,
                    SenderEmail = senderEmail,
                    RecieverEmail = recieverEmail,
                    Subject = subject,
                    MailText = mailText
                };
                SmtpClient client = new SmtpClient("smtp.yandex.com.tr", 587);
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(model.SenderEmail, "agileapptraining.com");
                mail.Priority = MailPriority.High;
                mail.Subject = model.Subject;
                mail.To.Add(new MailAddress(model.RecieverEmail, ""));
                mail.Body = model.MailText;
                mail.IsBodyHtml = true;

                NetworkCredential enter = new NetworkCredential(model.SenderEmail, "email password");
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Credentials = enter;
                client.Send(mail);
                if (model != null)
                {
                    await context.SendMails.AddAsync(model);
                    context.Entry(model).State = EntityState.Added;
                    var result = await context.SaveChangesAsync();
                    if (result > 0)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }

        }
    }
}
