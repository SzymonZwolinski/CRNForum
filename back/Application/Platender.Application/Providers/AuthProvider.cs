using Platender.Application.DTO;
using Platender.Core.Helpers;
using Platender.Core.Models;
using Platender.Core.Services;

namespace Platender.Application.Providers
{
	public class AuthProvider : IAuthProvider
	{
		private readonly IAuthService _authService;

		public AuthProvider(IAuthService authService)
		{
			_authService = authService;
		}

		public async Task<UserDto> RegisterUserAsync(string userName, string password)
		{
			CheckPassword(password);
			PasswordHelper.CreatePasswordHash(
				password, 
				out byte[] passwordHash,
				out byte[] passwordSalt);

			var user = await _authService.CreateUserAsync(userName, passwordHash, passwordSalt);

			return MapUserToUserDto(user);
		}

		public async Task<UserDto> LoginUserAsync(string userName, string password)
		{
			var (user, token) = await _authService.GetUserAndGenerateTokenAsync(userName, password);

			return new UserDto(
				user.Username, 
				user.UserStatus.ToString(), 
				token);
		}

		public async Task ChangePasswordAsync(
			string userName,
			string oldPassword,
			string newPassword)
        {
			var isUserValid = await _authService.IsLoginValidAsync(userName, oldPassword);

			if(!isUserValid)
			{
				return;
			}

			CheckPassword(newPassword);

			var user = await _authService.GetUserAsync(userName);
            PasswordHelper.CreatePasswordHash(
				newPassword, 
				out byte[] passwordHash, 
				out byte[] passwordSalt);

        }

		private UserDto MapUserToUserDto(User user)
		{
			return new UserDto(user.Username, user.UserStatus.ToString());
		}

		private void CheckPassword(string password)
		{
			if(password.Length > 15)
			{
				throw new ArgumentOutOfRangeException("Too long password");
			}

			if(string.IsNullOrWhiteSpace(password)) 
			{
				throw new ArgumentNullException("Password cannot be null");
			}
		}       
    }
}
