using Platender.Front.DTO;

namespace Platender.Front.Models
{
    public interface IUserAdapter
    {
        Task<User> AdaptBasicClaimsToUserAsync();
        void AdaptUserDtoToAccountState(UserDto userDto);
    }
}
