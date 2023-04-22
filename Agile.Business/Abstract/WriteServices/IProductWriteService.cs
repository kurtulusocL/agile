using Agile.Entities.Concrete;

namespace Agile.Business.Abstract.WriteServices
{
    public interface IProductWriteService
    {
        Task<bool> CreateAsync(int? companyId, int quantity, string name, string description, decimal price);
        Task<bool> UpdateAsync(int? companyId, int id, int quantity, string name, string description, decimal price);
        Task<bool> DeleteAsync(Product entity, int? id);
        Task<bool> CreateNewQuanity(int id, int quantity);
    }
}
