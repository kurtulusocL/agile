using Agile.Core.Entities.EntityFramework;

namespace Agile.Entities.Concrete
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
