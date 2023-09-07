using Platender.Core.Models;
using Platender.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platender.Core.Services
{
	public class AuthService : IAuthService
	{
		private readonly IAuthRepository _authRepository;

		public AuthService(IAuthRepository authRepository)
		{
			_authRepository = authRepository;
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
