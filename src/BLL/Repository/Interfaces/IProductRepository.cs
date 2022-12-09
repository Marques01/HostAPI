using BLL.Models;

namespace BLL.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task CreateAsync(Product model);

        void Update(Product model);

        void Delete(Product model);

        Task<Product> GetByIdAsync(int id);

        Task<IEnumerable<Product>> GetByNameAsync(string name);

        Task<IEnumerable<Product>> GetProductsAsync();

        Task<IEnumerable<Product>> GetByPricingAsync(decimal price);

        Task<IEnumerable<CategoryProduct>> GetByCategoryAsync(int id);        
    }
}
