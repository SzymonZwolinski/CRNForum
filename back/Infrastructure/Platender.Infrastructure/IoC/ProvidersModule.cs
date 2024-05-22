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
            builder.RegisterType<AuthProvider>().As<IAuthProvider>().InstancePerLifetimeScope(); 
            builder.RegisterType<EventProvider>().As<IEventProvider>().InstancePerLifetimeScope();
            builder.RegisterType<LikesProvider>().As<ILikesProvider>().InstancePerLifetimeScope();
            builder.RegisterType<UserProvider>().As<IUserProvider>().InstancePerLifetimeScope();
        }
    }
}
