using Platender.Front.Models;

namespace Platender.Front.Services
{
    public class UserService : IUserService
    {
        private readonly IUserAdapter _userAdapter;

        public UserService(IUserAdapter userAdapter)
        {
            _userAdapter = userAdapter;
        }

        public async Task<User> GetAuthorizedUser()
            => await _userAdapter.AdaptBasicClaimsToUserAsync();
    }
}