using Autofac;
using Platender.Core.Services;

namespace Platender.Infrastructure.IoC
{
	internal class ServicesModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);
			builder.RegisterType<PlateService>().As<IPlateService>().InstancePerLifetimeScope();
		}
	}
}
