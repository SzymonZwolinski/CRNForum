using Autofac;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Platender.Application.EF;
using Platender.Application.MiddleWare;
using Platender.Infrastructure.IoC;
using System.Text;

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
			services.AddDbContext<PlatenderDbContext>();

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

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration
					.GetRequiredSection("AppSettings:Token")
					.Value));

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.TokenValidationParameters = new TokenValidationParameters
					{
						IssuerSigningKey = key,

					};
				});
		}

		public void ConfigureContainer(ContainerBuilder builder)
		{
			builder.RegisterModule(new ContainerModule(Configuration));
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();
			else
				app.UseHsts();

			app.UseCors();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
			app.UseAuthorization();
			

			app.UseEndpoints(endpoints =>
			{
				//endpoints.MapGet("/", context => context.Response.WriteAsync("Gateway"));
				endpoints.MapControllers();
			});
		}
	}
}
