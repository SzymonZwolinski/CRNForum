using Autofac;
using Platender.Application.Repositories;
using Platender.Core.Repositories;

namespace Platender.Infrastructure.IoC
{
	internal class RepositoriesModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			builder.RegisterType<PlateRepository>().As<IPlateRepository>().InstancePerLifetimeScope();
			builder.RegisterType<AuthRepository>().As<IAuthRepository>().InstancePerLifetimeScope();
			builder.RegisterType<EventRepository>().As<IEventRepository>().InstancePerLifetimeScope();
			builder.RegisterType<LikesQueryRepository>().As<ILikesQueryRepository>().InstancePerLifetimeScope();
			builder.RegisterType<SpottsRepository>().As<ISpottsRepository>().InstancePerLifetimeScope();
		}
	}
}
