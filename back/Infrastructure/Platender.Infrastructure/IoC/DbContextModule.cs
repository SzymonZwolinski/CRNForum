using Autofac;
using Microsoft.Extensions.Configuration;
using Platender.Application.EF.Settings;

namespace Platender.Infrastructure.IoC
{
    public class DbContextModule : Module
    {
        private readonly IConfiguration _configuration;

        public DbContextModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            var sqlSettings = new SqlConnectionSettings();
            _configuration.GetSection("Sql").Bind(sqlSettings);

            builder.RegisterInstance(sqlSettings).SingleInstance();
        }
    }
}
