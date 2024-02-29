using Autofac;
using Platender.Core.Security;
using Platender.Core.Services;
using Platender.Infrastructure.Security;

namespace Platender.Infrastructure.IoC
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<PlateService>().As<IPlateService>().InstancePerLifetimeScope();
            builder.RegisterType<AuthService>().As<IAuthService>().InstancePerLifetimeScope();
            builder.RegisterType<JWTTokenService>().As<IJWTTokenService>().InstancePerLifetimeScope();
            builder.RegisterType<EventService>().As<IEventService>().InstancePerLifetimeScope();    
            builder.RegisterType<LikesService>().As<ILikesService>().InstancePerLifetimeScope();
        }
    }
}
