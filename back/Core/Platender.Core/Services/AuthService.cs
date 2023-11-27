using Platender.Core.Models;
using Platender.Core.Repositories;
using System.Security.Cryptography;

namespace Platender.Core.Services
{
	public class AuthService : IAuthService
	{
		private readonly IAuthRepository _authRepository;

		public AuthService(IAuthRepository authRepository)
		{
			_authRepository = authRepository;
		}

		public async Task<string> CheckLogin(string userName, string password)
		{
			var user = await _authRepository.GetUserAsync(userName);

			var isPasswordCorrect = VerifyPasswordHash(
				password,
				user.PasswordSalt, 
				user.PasswordHash);

			if(isPasswordCorrect) 
			{
				throw new Exception($"Invalid password for user {userName}");
			}
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

		private bool VerifyPasswordHash(
			string password,
			byte[] passwordHash,
			byte[] passwordSalt)
		{
			using (var hmac = new HMACSHA512(passwordSalt))
			{
				var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
				return computedHash == passwordHash;
			}
		}

		private string CreateJWTToken(User user)
		{
			

		}
	}
}
