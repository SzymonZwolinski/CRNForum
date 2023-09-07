using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Platender.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		[HttpPost("register")]
		public async<Task<ActionResult<UserDto>>> Register(RegisterUser request)
		{

		}
	}
}
