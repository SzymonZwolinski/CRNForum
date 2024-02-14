using Microsoft.AspNetCore.Mvc;
using Platender.Core.Models;

namespace Platender.Api.Controllers
{
	public class BaseController : ControllerBase
	{
		protected string UserName;

		protected void InitalizeHttpContextClaims()
		{
            var user = HttpContext.User;
            var userip = HttpContext.Connection.RemoteIpAddress;
            if (user != null && user.Identity.IsAuthenticated)
            {
                UserName = user.FindFirst("UserName").Value;
			}
        }
	}
}
