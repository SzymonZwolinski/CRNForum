using Autofac;
using Platender.Infrastructure.IoC;

namespace Platender.Api
{
	public class StartUp
	{
		public IConfiguration Configuration { get; }

		public StartUp(IConfiguration configuration)
		{
			Configuration = configuration;
		}


		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
			services.AddHttpContextAccessor();
		}

		public void ConfigureContainer(ContainerBuilder builder)
		{
			// Register your own things directly with Autofac, like:
			builder.RegisterModule(new ContainerModule(Configuration));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();
			else
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();

			app.UseCors();
            app.UseHttpsRedirection();
			app.UseAuthentication();
			app.UseRouting();
			app.UseAuthorization();
			

			app.UseEndpoints(endpoints =>
			{
				//endpoints.MapGet("/", context => context.Response.WriteAsync("Gateway"));
				endpoints.MapControllers();
			});
		}
	}
}
