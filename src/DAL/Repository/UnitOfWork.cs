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

            HostRepository = new HostRepository(_context);

            GameRepository = new GameRepository(_context);
            
            CapacityRepository = new CapacityRepository(_context);

            GameCapacityRepository= new GameCapacityRepository(_context);

            HostCapacityRepository = new HostCapacityRepository(_context);
        }

        public ICategoryRepository CategoryRepository { get; }

        public IProductRepository ProductRepository { get; }

        public ICategoryProductRepository CategoryProductRepository { get; }

        public IHostRepository HostRepository { get; }

        public IGameRepository GameRepository { get; }

        public ICapacityRepository CapacityRepository { get; }

        public IGameCapacityRepository GameCapacityRepository { get; }

        public IHostCapacityRepository HostCapacityRepository { get; }

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
