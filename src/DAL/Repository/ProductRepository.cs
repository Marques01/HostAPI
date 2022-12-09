using BLL.Models;
using BLL.Repository.Interfaces;
using DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Product model)
        {
            try
            {
                await _context.Products.AddAsync(model);
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possivel cadastrar o produto\n{ex.Message}");
            }
        }

        public void Delete(Product model)
        {
            try
            {
                _context.Products.Remove(model);
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possivel deletar o produto\n{ex.Message}");
            }
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            try
            {
                var products = await _context.Products!
                    .AsNoTracking()
                    .Include(x => x.CategoriesProducts)
                    .Include(x => x.Categories)
                    .ToListAsync();

                if (products != null)
                    return products;

                return Enumerable.Empty<Product>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possivel obter a lista de produtos\n{ex.Message}");
            }
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            try
            {
                var product = await _context.Products                    
                    .Include(x => x.CategoriesProducts)
                    .Include(x => x.Categories)
                    .FirstOrDefaultAsync(x => x.ProductId.Equals(id));

                if (product != null)
                    return product;

                return new Product();
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possivel buscar o produto pelo id\n{ex.Message}");
            }
        }

        public async Task<IEnumerable<Product>> GetByNameAsync(string name)
        {
            try
            {
                var products = await _context.Products
                    .AsNoTracking()
                    .Include(x => x.CategoriesProducts)
                    .Include(x => x.Categories)
                    .Where(x => x.Name.Contains(name))
                    .ToListAsync();

                if (products != null)
                    return products;

                return Enumerable.Empty<Product>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possivel obter os produtos pelo nome\n{ex.Message}");
            }
        }

        public void Update(Product model)
        {
            try
            {
                _context.Products.Update(model);
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possivel atualizar a o produto\n{ex.Message}");
            }
        }

        public async Task<IEnumerable<Product>> GetByPricingAsync(decimal price)
        {
            try
            {
                var products = await _context.Products.Where(x => x.Price.Equals(price)).ToListAsync();

                if (products != null)
                    return products;

                return Enumerable.Empty<Product>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possivel buscar os produtos pelo preço\n{ex.Message}");
            }
        }

        public async Task<IEnumerable<CategoryProduct>> GetByCategoryAsync(int id)
        {
            try
            {
                var products = await _context.CategoriesProducts
                    .Where(x => x.CategoryId.Equals(id))
                    .Include(x => x.Product)
                    .Include(x => x.Category)
                    .ToListAsync();

                if (products != null)
                    return products;

                return Enumerable.Empty<CategoryProduct>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possivel buscar os produtos pela categoria\n{ex.Message}");
            }
        }
    }
}
