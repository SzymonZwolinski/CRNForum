using Microsoft.AspNetCore.Mvc;

namespace Platender.Api.Controllers
{
	public class HomeController
	{
		[HttpGet("/")]
		public string Get()
		{
			return "Welcome in Platender Api :)";
		}
	}
}
