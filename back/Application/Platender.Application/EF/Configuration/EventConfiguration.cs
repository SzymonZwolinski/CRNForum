using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Platender.Core.Models;

namespace Platender.Application.EF.Configuration
{
    internal class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).IsRequired().HasMaxLength(63);
            builder.Property(x => x.Description).HasMaxLength(255);

            builder.Property(x => x.Longtitude).HasPrecision(5);
            builder.Property(x => x.Latitude).HasPrecision(5);

            builder.HasOne(x => x.Creator).WithOne();
            builder.HasMany(x => x.Participators).WithMany();
        }
    }
}
