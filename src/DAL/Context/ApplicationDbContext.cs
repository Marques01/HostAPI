using BLL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CategoryProduct> CategoriesProducts { get; set; }

        public DbSet<GameCapacity> GamesCapacities { get; set; }

        public DbSet<Host> Hosts { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Capacity> Capacities { get; set; }

        public DbSet<HostLoggin> HostLoggins { get; set; }

        public DbSet<HostCapacity> HostCapacities { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
            Products = Set<Product>();

            Categories = Set<Category>();

            CategoriesProducts = Set<CategoryProduct>();

            GamesCapacities = Set<GameCapacity>();

            Hosts = Set<Host>();

            Games = Set<Game>();

            Capacities = Set<Capacity>();

            HostLoggins = Set<HostLoggin>();

            HostCapacities = Set<HostCapacity>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.Cascade;

            base.OnModelCreating(modelBuilder);
        }
    }
}
