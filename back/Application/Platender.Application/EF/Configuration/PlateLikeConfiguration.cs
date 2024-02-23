using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

using Platender.Core.Models;

namespace Platender.Application.EF.Configuration
{
    internal class PlateLikeConfiguration : IEntityTypeConfiguration<PlateLike>
    {
        public void Configure(EntityTypeBuilder<PlateLike> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Plate)
                .WithMany(x => x.PlateLikes)
                .HasForeignKey(x => x.Id);
        }
    }
}
