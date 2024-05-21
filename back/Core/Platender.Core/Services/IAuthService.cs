using Platender.Core.Models;

namespace Platender.Core.Services
{
	public interface IAuthService
	{
		Task<User> CreateUserAsync(
			string userName, 
			byte[] passwordHash,
			byte[] passwordSalt);
		Task<User> GetUserAsync(string userName);
		Task<(User, string)> GetUserAndGenerateTokenAsync(string userName, string password);
		Task<bool> IsLoginValidAsync(string userName, string password);
		Task UpdateUserPasswordAsync(
			User user,
			byte[] passwordHash,
			byte[] passwordSalt);
	}
}
