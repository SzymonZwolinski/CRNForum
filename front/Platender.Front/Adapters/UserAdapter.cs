using Microsoft.AspNetCore.Components.Authorization;
using Platender.Front.DTO;
using Platender.Front.Helpers;
using Platender.Front.Models.Enums;
using Platender.Front.State;
using Platender.Front.Utilities;

namespace Platender.Front.Models
{
    public class UserAdapter : IUserAdapter
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly AccountState _accountState;

        public UserAdapter(
            AuthenticationStateProvider authenticationStateProvider,
            AccountState accountState)
        {
            _authenticationStateProvider = authenticationStateProvider;
            _accountState = accountState;
        }
        
        public async Task<User> AdaptBasicClaimsToUserAsync()
        {        
            var userClaims = await ((ApiAuthenticationStateProvider)_authenticationStateProvider).GetAuthenticationStateAsync();
            
			var username = userClaims?.User.Claims.FirstOrDefault(x => x.Type == "UserName");
			var user = new User(username?.Value);

            return user;
        }

        public void AdaptUserDtoToAccountState(UserDto userDto)
        {
            //TODO: ADD THIS TO TOKEN
            var user = new User(userDto.UserName, EnumHelper.MapStringToEnumOrNull<UserState>(userDto.UserStatus));

            _accountState.CurrentUser = user;
        }
    }
}