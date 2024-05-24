using Platender.Front.DTO;
using Platender.Front.Models;

namespace Platender.Front.Services
{
	public interface IAuthService
	{
		Task RegisterAsync(Account registerModel);
		Task LoginAsync(Account loginModel);
		Task Logout();
		Task ChangePasswordAsync(UserCredentialsDto userCredentialsDto);
	}
}
