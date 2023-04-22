using Agile.Core.Entities.EntityFramework;

namespace Agile.Entities.Concrete
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
      
        public int? CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
