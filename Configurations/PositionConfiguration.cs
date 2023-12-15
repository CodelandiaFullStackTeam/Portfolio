using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Areas.Admin.Models;

namespace Portfolio.Configurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.Deleted).HasDefaultValue<int>(0);
            builder.HasIndex(x=> new {x.Name, x.Deleted})
                   .IsUnique()
                   .HasDatabaseName("idx_Position_Name_Deleted");

        }
    }
}
