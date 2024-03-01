using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Platender.Core.Models;

namespace Platender.Application.EF.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Username).IsRequired();
            builder.Property(x => x.Username).HasMaxLength(31);
            builder.HasIndex(x => x.Username).IsUnique();

            builder.Property(x => x.UserStatus).HasConversion<string>().HasMaxLength(3);

            builder.Property(x => x.PasswordSalt).IsRequired();
            builder.Property(x => x.PasswordHash).IsRequired();

            builder.HasMany(x => x.EventUsers).WithOne(x => x.User);
        }
    }
}
