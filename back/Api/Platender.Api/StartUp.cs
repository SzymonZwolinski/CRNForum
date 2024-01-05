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
						ClockSkew = TimeSpan.Zero,
						IgnoreTrailingSlashWhenValidatingAudience = false,
						IssuerSigningKey = key,
						ValidateIssuerSigningKey = false,
						RequireExpirationTime = false,
						RequireAudience = false,
						RequireSignedTokens = false,
						ValidateAudience = false,
						ValidateIssuer = false,
						ValidateLifetime = false,
						ValidAudience = "api://my-audience/",
						ValidIssuer = "api://my-issuer/"
					};
				});
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
			//app.UseMiddleware<AuthenticationMiddleware>();
			

			app.UseEndpoints(endpoints =>
			{
				//endpoints.MapGet("/", context => context.Response.WriteAsync("Gateway"));
				endpoints.MapControllers();
			});
		}
	}
}
