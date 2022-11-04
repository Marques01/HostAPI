using BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.ProductId);
            builder.Property(x => x.Name).IsRequired().HasColumnType<string>("nvarchar(100)");
            builder.Property(x => x.ImagePath).HasColumnType<string>("nvarchar(125)");
            builder.Property(x => x.Price).HasColumnType("decimal(8,2)").HasPrecision(8, 2).HasConversion<decimal>();

            builder.HasMany(x => x.Categories)
                .WithMany(x => x.Products);
        }
    }
}
