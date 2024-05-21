using Platender.Application.DTO;

namespace Platender.Application.Providers
{
	public interface IAuthProvider
	{
		Task<UserDto> RegisterUserAsync(string userName, string password);
		Task<UserDto> LoginUserAsync(string userName, string password);
		Task ChangePasswordAsync(
			string userName,
			string oldPassword,
			string newPassword);
	}
}
