using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Principal;

namespace Platender.Api.Controllers
{
	public class BaseController : ControllerBase
	{
		protected string UserName;

		/*[HttpGet("/")]
		public string Get()
		{
			return "Welcome in Platender Api :)";
		}*/

		protected void InitalizeHttpContextClaims()
		{
			var user = HttpContext.User;
			if (user != null) 
			{
				UserName = user.FindFirst("UserName").Value;
			}
		}
	}
}
