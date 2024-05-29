using Platender.Core.Services;

namespace Platender.Application.Providers
{
    public class UserProvider : IUserProvider
    {
        private readonly IUserService _userService;

        public UserProvider(IUserService userService)
        {
            _userService = userService;
        }

        public async Task AddOrRemoveFavouritePlateAsync(Guid plateId, string userName)
            => await _userService.AddOrRemoveUserFavouritePlate(plateId, userName);

        public async Task ChangeUserAvatarAsync(byte[] avatar, string userName)
            => await _userService.ChangeUserAvatarAsync(avatar, userName);
    }
}
