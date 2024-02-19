using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Platender.Core.Models;

namespace Platender.Application.EF.Configuration
{
    internal class LikesConfiguration : IEntityTypeConfiguration<Likes>
    {
        public void Configure(EntityTypeBuilder<Likes> builder)
        {
            builder.HasKey(x => new { x.Id, x.TypeId });
        }
    }
}
