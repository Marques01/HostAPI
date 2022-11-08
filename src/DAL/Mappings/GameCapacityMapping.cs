using BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Mappings
{
    public class GameCapacityMapping : IEntityTypeConfiguration<GameCapacity>
    {
        public void Configure(EntityTypeBuilder<GameCapacity> builder)
        {
            builder.ToTable("GameCapacity");

            builder.HasKey(x => x.GameCapacityId);

            builder.HasOne(x => x.Capacity)
                .WithMany(x => x.GamesCapacities)
                .HasForeignKey(x => x.CapacityId);

            builder.HasOne(x => x.Game)
                .WithMany(x => x.GamesCapacities)
                .HasForeignKey(x => x.GameId);
        }
    }
}
