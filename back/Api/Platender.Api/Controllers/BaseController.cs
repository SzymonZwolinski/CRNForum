using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Platender.Api.Controllers
{
	public class BaseController : ControllerBase
	{
		protected string UserName;
		protected IPAddress UserIP;

		protected void InitalizeHttpContextClaims()
		{
			var user = HttpContext.User;

			if(user is not null && user.Identity.IsAuthenticated)
			{
				UserName = user.FindFirst("UserName").Value;
			}
		}

		protected void InitializeHttpContextIP()
		{
			var userIP = HttpContext.Connection.RemoteIpAddress;

			if(userIP is not null)
			{
				UserIP = userIP;
			}
		}
	}
}
