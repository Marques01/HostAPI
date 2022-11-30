namespace BLL.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        public IProductRepository ProductRepository { get; }

        public ICategoryRepository CategoryRepository { get; }

        public ICategoryProductRepository CategoryProductRepository { get; }

        public IHostRepository HostRepository { get; }

        public IGameRepository GameRepository { get; }

        public ICapacityRepository CapacityRepository { get; }

        public IGameCapacityRepository GameCapacityRepository { get; }

        public IHostCapacityRepository HostCapacityRepository { get; }

        public IRoleIdentityRepository RoleIdentityRepository { get; }

        public IUserRepository UserRepository { get; }

        Task CommitAsync();

        Task DisposeAsync();
    }
}
