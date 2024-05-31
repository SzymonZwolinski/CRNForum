using Platender.Front.DTO;
using Platender.Front.Helpers;
using Platender.Front.Models;

namespace Platender.Front.Services
{
	public interface IUserService
	{
		Task<User> GetAuthorizedUser();
		Task AddOrRemoveUserFavouritePlateAsync(UserFavouritePlate userFavouriePlate);
		Task UpdateUserAvatarAsync(AvatarDto avatar);
		Task<PagedData<UserFavouritePlateDto>> GetUserFavouritePlatesAsync(int page);
	}
}
