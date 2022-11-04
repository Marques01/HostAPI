using BLL.Models;

namespace BLL.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        Task Create(Category category);

        void Update(Category category);

        void Delete(Category category);

        Task<IEnumerable<Category>> GetCategories();

        Task<IEnumerable<Category>> GetByName(string name);

        Task<Category> GetById(Guid id);        
    }
}
