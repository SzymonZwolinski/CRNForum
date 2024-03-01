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

            var sqlSettings = _configuration.GetSection(SqlConnectionSettings.CONFIG_NAME).Get<SqlConnectionSettings>();

            builder.RegisterInstance(sqlSettings).SingleInstance();
        }
    }
}
