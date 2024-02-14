using Autofac;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Platender.Application.EF;
using Platender.Infrastructure.IoC;
using Platender.Infrastructure.Options;
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

            var tokenSettings = Configuration.GetSection(TokenSettings.CONFIG_NAME).Get<TokenSettings>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ClockSkew = TimeSpan.FromMinutes(1),
                        IgnoreTrailingSlashWhenValidatingAudience = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(tokenSettings.SigningKey)),
                        ValidateIssuerSigningKey = tokenSettings.ValidateSigningKey,
                        RequireExpirationTime = true,
                        RequireAudience = true,
                        RequireSignedTokens = true,
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidAudience = tokenSettings.Audience,
                        ValidIssuer = tokenSettings.Issuer
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
