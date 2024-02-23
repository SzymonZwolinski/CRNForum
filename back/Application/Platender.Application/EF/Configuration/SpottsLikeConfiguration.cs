using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Platender.Core.Models;

namespace Platender.Application.EF.Configuration
{
    internal class SpottsLikeConfiguration : IEntityTypeConfiguration<SpottLike>
    {
        public void Configure(EntityTypeBuilder<SpottLike> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Spott)
                .WithMany(x => x.SpottLikes)
                .HasForeignKey(x => x.Id);
        }
    }
}
