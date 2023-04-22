using Agile.Core.Entities.EntityFramework;

namespace Agile.Entities.Concrete
{
    public class Customer : BaseEntity
    {
        public string NameSurname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<SendMail> SendMails { get; set; }
    }
}
