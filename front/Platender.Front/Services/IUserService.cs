using Platender.Front.Models;

namespace Platender.Front.Services
{
	public interface IUserService
	{
		Task<User> GetAuthorizedUser();
		Task UpdateUserAvatarAsync(byte[] avatar);
	}
}
