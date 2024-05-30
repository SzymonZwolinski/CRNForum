using Platender.Application.DTO;
using Platender.Core.Helpers;

namespace Platender.Application.Providers
{
    public interface IUserProvider
    {
        Task ChangeUserAvatarAsync(byte[] avatar, string userName);
        Task AddOrRemoveFavouritePlateAsync(Guid plateId, string userName);
        Task<PagedData<FavouritePlateDto>> GetUserFavouritePlatesAsync(int page, string userName);
    }
}
