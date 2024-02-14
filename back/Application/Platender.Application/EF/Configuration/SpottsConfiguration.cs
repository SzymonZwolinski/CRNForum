using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Platender.Core.Models;

namespace Platender.Application.EF.Configuration
{
    internal class SpottsConfiguration : IEntityTypeConfiguration<Spotts>
    {
        public void Configure(EntityTypeBuilder<Spotts> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Plate).WithMany(x => x.Spotts);

            builder.Property(x => x.Description).HasMaxLength(255);
        }
    }
}
