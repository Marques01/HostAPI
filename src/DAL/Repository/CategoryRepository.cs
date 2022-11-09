using BLL.Models;
using BLL.Repository.Interfaces;
using DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Category category)
        {
            try
            {
                await _context.Categories.AddAsync(category);
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possivel salvar a categoria\n{ex.Message}");
            }
        }

        public void Delete(Category category)
        {
            try
            {
                _context.Categories.Remove(category);
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível remover a categoria\n{ex.Message}");
            }
        }

        public async Task<Category> GetById(Guid id)
        {
            try
            {
                var category = await _context.Categories
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.CategoryId.Equals(id));

                if (category != null)
                    return category;

                return new Category();
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível buscar a categoria pelo id\n{ex.Message}");
            }
        }

        public async Task<IEnumerable<Category>> GetByName(string name)
        {
            try
            {
                var categories = await _context.Categories
                    .AsNoTracking()
                    .Where(x => x.Name.Contains(name))
                    .ToListAsync();

                if (categories != null)
                    return categories;

                return Enumerable.Empty<Category>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível buscar a categoria pelo nome\n{ex.Message}");
            }
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            try
            {
                var categories = await _context.Categories.AsNoTracking().OrderBy(x => x.Name).ToListAsync();

                if (categories != null)
                    return categories;

                return Enumerable.Empty<Category>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível buscar todas as categorias\n{ex.Message}");
            }
        }

        public void Update(Category category)
        {
            try
            {
                _context.Categories.Update(category);
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível atualizar a categoria\n{ex.Message}");
            }
        }
    }
}
