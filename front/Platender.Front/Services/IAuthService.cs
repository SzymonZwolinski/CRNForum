using Platender.Front.DTO;
using Platender.Front.Models;
using Platender.Front.State;

namespace Platender.Front.Services
{
	public interface IAuthService
	{
		Task RegisterAsync(Account registerModel);
		Task LoginAsync(Account loginModel, AccountState accountState);
		Task Logout();
		Task ChangePasswordAsync(UserCredentialsDto userCredentialsDto);
	}
}
