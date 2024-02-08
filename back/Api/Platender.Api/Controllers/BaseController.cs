using Microsoft.AspNetCore.Mvc;

namespace Platender.Api.Controllers
{
	public class BaseController : ControllerBase
	{
		protected string UserName;

		protected void InitalizeHttpContextClaims()
		{
            var user = HttpContext.User;

            if (user != null && user.Identity.IsAuthenticated)
            {
                UserName = user.FindFirst("UserName").Value;
			}
        }
	}
}
