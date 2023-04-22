using Agile.Core.DataAccess;
using Agile.Entities.Concrete;
using System.ComponentModel.Design;

namespace Agile.DataAccess.Abstract.WriteDALs
{
    public interface IProductWriteDal : IEntityWriteRepository<Product>
    {
        Task<bool> CreateAsync(int? companyId, int quantity, string name, string description, decimal price);
        Task<bool> UpdateAsync(int? companyId, int id, int quantity, string name, string description, decimal price);
        Task<bool> CreateNewQuanity(int id,  int quantity);
    }
}
