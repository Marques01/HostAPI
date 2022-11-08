using BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Mappings
{
    public class HostCapacityMapping : IEntityTypeConfiguration<HostCapacity>
    {
        public void Configure(EntityTypeBuilder<HostCapacity> builder)
        {
            builder.ToTable("HostCapacity");
            builder.HasKey(x => x.HostCapacityId);
            
            builder.HasOne(x => x.Host)
                .WithMany(x => x.HostCapacities)
                .HasForeignKey(x => x.HostId);

            builder.HasOne(x => x.GameCapacity)
                .WithMany(x => x.HostCapacities)
                .HasForeignKey(x => x.GameCapacityId);
        }
    }
}
