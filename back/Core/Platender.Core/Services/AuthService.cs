using Platender.Core.Helpers;
using Platender.Core.Models;
using Platender.Core.Repositories;
using Platender.Core.Security;

namespace Platender.Core.Services
{
	public class AuthService : IAuthService
	{
		private readonly IAuthRepository _authRepository;
		private readonly IJWTTokenService _jwtTokenService;

		public AuthService(IAuthRepository authRepository, IJWTTokenService jwtTokenService)
		{
			_authRepository = authRepository;
			_jwtTokenService = jwtTokenService;
		}

		public async Task<string> CheckLogin(string userName, string password)
		{
			var user = await _authRepository.GetUserAsync(userName);

			if(user is null)
			{
				throw new Exception($"user with name {userName} does not exists");
			}

			var isPasswordCorrect = PasswordHelper.VerifyPasswordHash(
				password,
				user.PasswordSalt, 
				user.PasswordHash);

			if(isPasswordCorrect) 
			{
				throw new Exception($"Invalid password for user {userName}");
			}

			return _jwtTokenService.GenerateToken(user);
		}

		public async Task<User> CreateUserAsync(
			string userName,
			byte[] passwordHash,
			byte[] passwordSalt)
		{
			var user = new User(
				userName, 
				passwordHash, 
				passwordSalt);

			await _authRepository.CreateUserAsync(user);

			return user;
		}
	}
}
