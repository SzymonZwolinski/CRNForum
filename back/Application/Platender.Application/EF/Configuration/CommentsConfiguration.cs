using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Platender.Core.Models;

namespace Platender.Application.EF.Configuration
{
    internal class CommentsConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Plate).WithMany(x => x.Comments);

            builder.Property(x => x.Description).HasMaxLength(255);
        }
    }
}
