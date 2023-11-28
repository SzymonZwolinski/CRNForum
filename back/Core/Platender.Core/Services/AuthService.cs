using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Platender.Core.Helpers;
using Platender.Core.Models;
using Platender.Core.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Platender.Core.Services
{
	public class AuthService : IAuthService
	{
		private readonly IAuthRepository _authRepository;
		private readonly IConfiguration _configuration;

		public AuthService(IAuthRepository authRepository, IConfiguration configuration)
		{
			_authRepository = authRepository;
			_configuration = configuration;
		}

		public async Task<string> CheckLogin(string userName, string password)
		{
			var user = await _authRepository.GetUserAsync(userName);

			var isPasswordCorrect = PasswordHelper.VerifyPasswordHash(
				password,
				user.PasswordSalt, 
				user.PasswordHash);

			if(isPasswordCorrect) 
			{
				throw new Exception($"Invalid password for user {userName}");
			}

			return JwtTokenHelper.CreateJWTToken(
				user,
				_configuration
					.GetRequiredSection("AppSettings:Token")
					.Value);
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
