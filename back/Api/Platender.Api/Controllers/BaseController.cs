using Microsoft.AspNetCore.Mvc;

namespace Platender.Api.Controllers
{
	public class BaseController : ControllerBase
	{
		protected string UserName;

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
