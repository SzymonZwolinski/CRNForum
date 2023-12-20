using Microsoft.EntityFrameworkCore;
using Platender.Application.EF.Configuration;
using Platender.Application.EF.Settings;

namespace Platender.Application.EF
{
    internal class PlatenderDbContext : DbContext
    {
        private readonly SqlConnectionSettings _connectionSettings;
        public PlatenderDbContext(SqlConnectionSettings connectionSettings)
        {
            _connectionSettings = connectionSettings;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionSettings.BuildConnectionStrings());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlateConfiguration());
        }
    }
}
