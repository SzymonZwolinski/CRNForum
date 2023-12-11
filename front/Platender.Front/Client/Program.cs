using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Platender.Front;
using Platender.Front.Services;
using Platender.Front.Utilities;
using System;


namespace Platender.Front
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("#app");
			builder.RootComponents.Add<HeadOutlet>("head::after");


			builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
			
			builder.Services.AddBlazoredLocalStorage();
			builder.Services.AddAuthorizationCore();

			builder.Services.AddSingleton(new BackendConfig { Url = builder.Configuration["BackendUrl"] });

			builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
			builder.Services.AddScoped<IAuthService, AuthService>();
			builder.Services.AddScoped<IPlateService, PlateService>();
			await builder.Build().RunAsync();
		}
	}
}