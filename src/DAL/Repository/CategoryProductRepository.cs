using BLL.Models;
using BLL.Repository.Interfaces;
using DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class CategoryProductRepository : ICategoryProductRepository
    {
		private ApplicationDbContext _context;

		public CategoryProductRepository(ApplicationDbContext context)
		{
			_context = context;		
		}

        public async Task<IEnumerable<CategoryProduct>> GetProductsByCategory(Guid categoryId)
        {
			try
			{
				var products = await _context.CategoriesProducts
					.AsNoTracking()
					.ToListAsync();

				if (products != null)
					return products;

				return Enumerable.Empty<CategoryProduct>();
            }
			catch (Exception ex)
			{
				throw new Exception($"Não foi possivel obter a lista de produtos relacionado a categoria\n{ex.Message}");
			}
        }
    }
}
