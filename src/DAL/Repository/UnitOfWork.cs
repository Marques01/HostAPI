using BLL.Repository.Interfaces;
using DAL.Context;

namespace DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            ProductRepository = new ProductRepository(_context);

            CategoryProductRepository = new CategoryProductRepository(_context);

            CategoryRepository = new CategoryRepository(_context);
        }

        public ICategoryRepository CategoryRepository { get; }

        public IProductRepository ProductRepository { get; }

        public ICategoryProductRepository CategoryProductRepository { get; }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
