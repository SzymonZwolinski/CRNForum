using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Platender.Application.Commands;
using Platender.Application.DTO;
using Platender.Application.Providers;

namespace Platender.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IAuthProvider _authProvider;

		public AuthController(IAuthProvider authProvider)
		{
			_authProvider = authProvider;
		}

		[HttpPost("register")]
		public async Task<ActionResult<UserDto>> Register(UserLogin registerUserCommand)
		{
			var registeredUser = 
				await _authProvider.RegisterUserAsync(
					registerUserCommand.UserName,
					registerUserCommand.Password);

			return Ok(registeredUser.UserName);//Shouldnt return value
		}

		[HttpPost("login")]
		public async Task<ActionResult<string>> Login(UserLogin loginUserCommand)
		{
			
		}
	}
}
