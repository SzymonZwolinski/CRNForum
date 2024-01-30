using Autofac;
using Microsoft.Extensions.Configuration;

namespace Platender.Infrastructure.IoC
{
	public class ContainerModule : Module
	{
		private readonly IConfiguration _configuration;

		public ContainerModule(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			builder.RegisterModule<ServicesModule>();
			builder.RegisterModule<RepositoriesModule>();
			builder.RegisterModule<ProvidersModule>();
						
			builder.RegisterModule(new DbContextModule(_configuration));
			builder.RegisterModule(new SettingsModule(_configuration));

		}
	}
}
