using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Platender.Application.Messages;
using Platender.Application.Providers;

namespace Platender.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IUserProvider _userProvider;

        public AccountController(IUserProvider userProvider)
        {
            _userProvider = userProvider;
        }

        [Authorize]
        [HttpPut("/avatar")]
        public async Task<IResult> ChangeUserAvatar([FromBody] ChangeAvatar changeAvatar)
        {
            InitalizeHttpContextClaims();

            await _userProvider.ChangeUserAvatarAsync(changeAvatar.Avatar, UserName);

            return Results.Ok();
        }
    }
}
