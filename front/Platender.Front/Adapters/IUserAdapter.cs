using Platender.Front.DTO;
using Platender.Front.State;

namespace Platender.Front.Models
{
    public interface IUserAdapter
    {
        Task<User> AdaptBasicClaimsToUserAsync();
        void AdaptUserDtoToAccountState(UserDto userDto, AccountState accountState);
    }
}
