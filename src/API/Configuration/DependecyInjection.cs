using BLL.Repository.Interfaces;
using DAL.Repository;

namespace API.Configuration
{
    public static class DependecyInjection
    {
        public static void RegisterDependencyInjection(IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryProductRepository, CategoryProductRepository>();
            services.AddScoped<IHostRepository, HostRepository>();
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<ICapacityRepository, CapacityRepository>();
            services.AddScoped<IGameCapacityRepository, GameCapacityRepository>();
            services.AddScoped<IHostCapacityRepository, HostCapacityRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
