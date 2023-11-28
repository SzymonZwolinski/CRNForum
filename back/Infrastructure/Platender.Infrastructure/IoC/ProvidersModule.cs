using Autofac;
using Platender.Application.Providers;

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
