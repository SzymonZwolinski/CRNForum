using Platender.Core.Repositories;

namespace Platender.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IPlateRepository _plateRepository;

        public UserService(
            IAuthRepository authRepository,
            IPlateRepository plateRepository)
        {
            _authRepository = authRepository;
            _plateRepository = plateRepository;
        }

        public async Task AddOrRemoveUserFavouritePlate(Guid plateId, string userName)
        {
            var user = await _authRepository.GetUserWithFavouritePlatesAsync(userName);

            if (user is null)
            {
                throw new ArgumentNullException($"Could not find user with userName: {userName}");
            }

            var plate = await _plateRepository.GetPlateAsync(plateId);
            
            if(plate is null)
            {
                throw new ArgumentNullException($"Could not find plate with id: {plateId}");
            }

            if (user.favouritePlates.Any(x => x.Plate.Id == plate.Id))
            {
                user.RemoveFavouritePlate(plate);
            }
            else
            {
                user.AddFavouritePlate(plate);
            }

            await _authRepository.UpdateUserAsync(user);
        }

        public async Task ChangeUserAvatarAsync(byte[] avatar, string userName)
        {
            var user = await _authRepository.GetUserAsync(userName);

            user.SetAvatar(avatar);

            await _authRepository.UpdateUserAsync(user);
        }
    }
}
