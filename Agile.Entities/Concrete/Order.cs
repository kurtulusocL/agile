using Agile.Core.Entities.EntityFramework;

namespace Agile.Entities.Concrete
{
    public class Order : BaseEntity
    {
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ExpectedOrderDate { get; set; }

        public int? ProductId { get; set; }
        public int? CustomerId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
