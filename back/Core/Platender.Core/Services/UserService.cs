using Platender.Core.Repositories;

namespace Platender.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IAuthRepository _authRepository;

        public UserService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task ChangeUserAvatarAsync(byte[] avatar, string userName)
        {
            var user = await _authRepository.GetUserAsync(userName);

            user.SetAvatar(avatar);

            await _authRepository.UpdateUserAsync(user);
        }
    }
}
