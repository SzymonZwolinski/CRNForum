using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Platender.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platender.Application.EF.Configuration
{
    public class PlateConfiguration : IEntityTypeConfiguration<Plate>
    {
        public void Configure(EntityTypeBuilder<Plate> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Comments).WithOne(x => x.plate).OnDelete(DeleteBehavior.Cascade);
            builder.Property(x => x.Number).HasMaxLength(7);
        }
    }
}
