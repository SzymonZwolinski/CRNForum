using Platender.Core.Models;

namespace Platender.Core.Services
{
	public interface IAuthService
	{
		Task<User> CreateUserAsync(
			string userName, 
			byte[] passwordHash,
			byte[] passwordSalt);

		Task<string> CheckLogin(string userName, string password);
	}
}
