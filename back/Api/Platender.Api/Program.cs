using Autofac.Extensions.DependencyInjection;
using Platender.Infrastructure.ScheduledTasks;

namespace Platender.Api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args)
		{
			return Host.CreateDefaultBuilder(args)
				.UseServiceProviderFactory(new AutofacServiceProviderFactory())
				.ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<StartUp>(); })
				.ConfigureServices(services =>
				{
					services.AddHostedService<CreateTopLikesViewsTask>();
				});
		}
	}
}