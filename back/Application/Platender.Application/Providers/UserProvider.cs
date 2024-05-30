using Platender.Application.DTO;
using Platender.Core.Helpers;
using Platender.Core.Services;

namespace Platender.Application.Providers
{
    public class UserProvider : IUserProvider
    {
        private readonly IUserService _userService;
        private readonly IPlateService _plateService;
        private readonly IAuthService _authService;
        public UserProvider(
            IUserService userService,
            IPlateService plateService,
            IAuthService authService)
        {
            _userService = userService;
            _plateService = plateService;
            _authService = authService;
        }

        public async Task AddOrRemoveFavouritePlateAsync(Guid plateId, string userName)
            => await _userService.AddOrRemoveUserFavouritePlate(plateId, userName);

        public async Task ChangeUserAvatarAsync(byte[] avatar, string userName)
            => await _userService.ChangeUserAvatarAsync(avatar, userName);

        public async Task<PagedData<FavouritePlateDto>> GetUserFavouritePlatesAsync(int page, string userName)
        {
            var user = await _authService.GetUserAsync(userName);
            var (plates, count) = await _plateService.GetFavouritePlatesAsync(page, user);

            return new PagedData<FavouritePlateDto>(
                plates.Select(
                    x => MapToFavouritePlateDto(
                        x.Id, 
                        x.Number, 
                        x.Culture.ToString())),
                    count);
        }

        private FavouritePlateDto MapToFavouritePlateDto(Guid id, string number, string culture)
            => new FavouritePlateDto(id, number, culture);
    }
}
