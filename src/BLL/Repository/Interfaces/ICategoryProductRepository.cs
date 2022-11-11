using BLL.Models;

namespace BLL.Repository.Interfaces
{
    public interface ICategoryProductRepository
    {
        Task<IEnumerable<CategoryProduct>> GetProductsByCategory(int categoryId);
    }
}
