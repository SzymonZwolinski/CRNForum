using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Platender.Application.Messages;
using Platender.Application.Providers;

namespace Platender.Api.Controllers
{
    [Route("[Controller]")]
    public class AccountController : BaseController
    {
        private readonly IUserProvider _userProvider;
        private readonly IAuthProvider _authProvider;

        public AccountController(IUserProvider userProvider, IAuthProvider authProvider)
        {
            _userProvider = userProvider;
            _authProvider = authProvider;
        }

        [Authorize]
        [HttpPatch("password")]
        public async Task<ActionResult<string>> ChangePassword([FromBody] ChangePassword changePasswordCommand)
        {
            InitalizeHttpContextClaims();

            await _authProvider.ChangePasswordAsync(
                UserName,
                changePasswordCommand.OldPassword,
                changePasswordCommand.NewPassword);

            return Ok();
        }

        [Authorize]
        [HttpPut("avatar")]
        public async Task<ActionResult<string>> ChangeUserAvatar([FromBody] ChangeAvatar changeAvatar)
        {
            InitalizeHttpContextClaims();

            await _userProvider.ChangeUserAvatarAsync(changeAvatar.Avatar, UserName);

            return Ok();
        }
    }
}
