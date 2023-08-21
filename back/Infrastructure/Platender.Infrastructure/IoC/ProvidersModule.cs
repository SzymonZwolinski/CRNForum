using Autofac;
using Platender.Application.Providers;
using Platender.Application.Repositories;
using Platender.Core.Repositories;

namespace Platender.Infrastructure.IoC
{
    internal class ProvidersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<PlateProvider>().As<IPlateProvider>().InstancePerLifetimeScope();
        }
    }
}
