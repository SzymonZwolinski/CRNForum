using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Platender.Core.Models;

namespace Platender.Application.EF.Configuration
{
    internal class CommentsLikeConfiguration : IEntityTypeConfiguration<CommentsLike>
    {
        public void Configure(EntityTypeBuilder<CommentsLike> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Comment)
                .WithMany(x => x.CommentLike)
                .HasForeignKey(x => x.CommentId);

            builder.Property(x => x.LikeType)
                .HasConversion<string>()
                .HasMaxLength(4);
        }
    }
}
