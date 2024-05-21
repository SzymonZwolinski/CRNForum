using Platender.Core.Models;

namespace Platender.Core.Repositories
{
	public interface IAuthRepository
	{
		Task CreateUserAsync(User user);
        Task<User> GetUserAsync(string userName);
		Task UpdateUserAsync(User user);
	}
}
