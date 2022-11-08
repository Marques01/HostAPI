namespace BLL.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        public IProductRepository ProductRepository { get; }

        public ICategoryRepository CategoryRepository { get; }

        public ICategoryProductRepository CategoryProductRepository { get; }

        public IHostRepository HostRepository { get; }

        Task CommitAsync();

        Task DisposeAsync();
    }
}
