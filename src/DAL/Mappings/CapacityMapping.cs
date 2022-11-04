using BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Mappings
{
    public class CapacityMapping : IEntityTypeConfiguration<Capacity>
    {
        public void Configure(EntityTypeBuilder<Capacity> builder)
        {
            builder.ToTable("Capacity");
            builder.HasKey(x => x.CapacityId);
            builder.Property(x => x.Slots).IsRequired();
        }
    }
}
