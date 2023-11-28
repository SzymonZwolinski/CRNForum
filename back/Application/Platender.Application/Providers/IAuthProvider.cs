using Platender.Application.DTO;

namespace Platender.Application.Providers
{
	public interface IAuthProvider
	{
		Task<UserDto> RegisterUserAsync(string userName, string password);
		Task<string> LoginUserAsync(string userName, string password);
	}
}
