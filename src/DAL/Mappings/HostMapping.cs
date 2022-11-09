using BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Mappings
{
    public class HostMapping : IEntityTypeConfiguration<Host>
    {
        public void Configure(EntityTypeBuilder<Host> builder)
        {
            builder.ToTable("Host");
            builder.HasKey(x => x.HostId);
            builder.Property(x => x.Name).IsRequired().HasColumnType<string>("nvarchar(125)");
            builder.Property(x => x.CreateAt).IsRequired().HasColumnType<string>("nvarchar(10)");
            builder.Property(x => x.UpdateAt).IsRequired().HasColumnType<string>("nvarchar(10)");
            builder.Property(x => x.Door).IsRequired();
            builder.Property(x => x.Enabled).IsRequired();
        }
    }
}
