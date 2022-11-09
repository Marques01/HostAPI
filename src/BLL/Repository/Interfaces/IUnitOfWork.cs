﻿namespace BLL.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        public IProductRepository ProductRepository { get; }

        public ICategoryRepository CategoryRepository { get; }

        public ICategoryProductRepository CategoryProductRepository { get; }

        public IHostRepository HostRepository { get; }

        public IGameRepository GameRepository { get; }

        public ICapacityRepository CapacityRepository { get; }

        public IGameCapacityRepository GameCapacityRepository { get; set; }

        Task CommitAsync();

        Task DisposeAsync();
    }
}
