using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Platender.Core.Models;

namespace Platender.Application.EF.Configuration
{
    internal class UserFavouritePlatesConfiguration : IEntityTypeConfiguration<UserFavouritePlates>
    {
        public void Configure(EntityTypeBuilder<UserFavouritePlates> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
