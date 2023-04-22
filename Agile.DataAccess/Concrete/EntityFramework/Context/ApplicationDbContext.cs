using Agile.Core.Entities.EntityFramework;
using Agile.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Agile.DataAccess.Concrete.EntityFramework.Context
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=KURTULUSOCAL\\KURTULUSOCL;Database=agile;user Id=sa;Password=123");
        }

        public DbSet<Company> Companies{ get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SendMail> SendMails { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();           
            foreach (var item in datas)
            {
                _ = item.State switch
                {
                    EntityState.Added => item.Entity.CreatedDate = DateTime.Now.ToLocalTime(),
                    EntityState.Modified => item.Entity.UpdatedDate = DateTime.Now.ToLocalTime(),
                    _ => DateTime.Now.ToLocalTime()
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
