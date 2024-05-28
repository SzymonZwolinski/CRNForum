using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Platender.Application.DTO;
using Platender.Application.Messages;
using Platender.Application.Providers;

namespace Platender.Api.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class AuthController : BaseController
    {
		private readonly IAuthProvider _authProvider;

		public AuthController(IAuthProvider authProvider)
		{
			_authProvider = authProvider;
		}

		[HttpPost("register")]
		public async Task<ActionResult<UserDto>> Register([FromBody] UserLogin registerUserCommand)
		{
			var registeredUser = 
				await _authProvider.RegisterUserAsync(
					registerUserCommand.UserName,
					registerUserCommand.Password);

			return Ok(registeredUser.UserName);
		}

		[HttpPost("login")]
		public async Task<ActionResult<UserDto>> Login([FromBody] UserLogin loginUserCommand)
		{
			var user = await _authProvider.LoginUserAsync(
				loginUserCommand.UserName, 
				loginUserCommand.Password);

			return Ok(user);
		}
	}
}
