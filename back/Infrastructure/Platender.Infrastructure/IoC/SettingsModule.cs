using Autofac;
using Microsoft.Extensions.Configuration;
using Platender.Infrastructure.Options;

namespace Platender.Infrastructure.IoC
{
    public class SettingsModule : Module
    {
        private readonly IConfiguration _configuration;

        public SettingsModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            var tokenSettings = _configuration.GetSection(TokenSettings.CONFIG_NAME).Get<TokenSettings>();

            builder.RegisterInstance(tokenSettings).SingleInstance();
        }
    }
}
