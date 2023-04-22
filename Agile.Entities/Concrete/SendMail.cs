using Agile.Core.Entities.EntityFramework;

namespace Agile.Entities.Concrete
{
    public class SendMail : BaseEntity
    {
        public string SenderEmail { get; set; }
        public string RecieverEmail { get; set; }
        public string Subject { get; set; }
        public string MailText { get; set; }

        public int? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
