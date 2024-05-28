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
		private List<Exception> ErrorList = new();

		public AuthService(IAuthRepository authRepository, IJWTTokenService jwtTokenService)
		{
			_authRepository = authRepository;
			_jwtTokenService = jwtTokenService;
		}

		public async Task<(User, string)> GetUserAndGenerateTokenAsync(string userName, string password)
		{
			var user = await _authRepository.GetUserAsync(userName);

            ValidateUserData(
				user,
				password,
				userName);

            return (user, _jwtTokenService.GenerateToken(user));
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

		public async Task<User> GetUserAsync(string userName)
			=> await _authRepository.GetUserAsync(userName);
            
        public async Task<bool> IsLoginValidAsync(string userName, string password)
        {
            var user = await _authRepository.GetUserAsync(userName);

			ValidateUserData(
				user,
				password,
				userName);

			return true;
        }

        public async Task UpdateUserPasswordAsync(
			User user,
			byte[] passwordHash,
			byte[] passwordSalt)
        {
            user.ChangePassword(passwordHash, passwordSalt);

			await _authRepository.UpdateUserAsync(user);
        }

        private void ValidateUserData(
			User user, 
			string password,
			string username)
		{
			ErrorList.Clear();
            if (user is null)
            {
                ErrorList.Add(new ArgumentException($"user not found"));
            }

            var isPasswordCorrect = PasswordHelper.VerifyPasswordHash(
                password,
                user.PasswordHash,
                user.PasswordSalt);

            if (!isPasswordCorrect)
            {
                ErrorList.Add(new ArgumentException($"Invalid password"));
            }

			if(ErrorList.Any())
			{
				throw new AggregateException(
					$"Errors while validating username: {username}", 
					ErrorList);
			}
        }
    }
}
