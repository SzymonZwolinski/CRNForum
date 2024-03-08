using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Platender.Core.Models;

namespace Platender.Application.EF.Configuration
{
    public class PlateConfiguration : IEntityTypeConfiguration<Plate>
    {
        public void Configure(EntityTypeBuilder<Plate> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Comments).WithOne(x => x.Plate).OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.Number).HasMaxLength(7);
            builder.Property(x => x.Number).IsUnicode(false);
            builder.Property(x => x.Culture)
                .HasConversion<string>()
                .HasMaxLength(4);
        }
    }
}
