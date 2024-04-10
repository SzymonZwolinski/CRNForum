using Microsoft.AspNetCore.Components.Authorization;
using Platender.Front.Utilities;

namespace Platender.Front.Models
{
    public class UserAdapter : IUserAdapter
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public UserAdapter(AuthenticationStateProvider authenticationStateProvider)
        {
            _authenticationStateProvider = authenticationStateProvider;
        }
        
        public async Task<User> AdaptBasicClaimsToUserAsync()
        {        
            var userClaims = await ((ApiAuthenticationStateProvider)_authenticationStateProvider).GetAuthenticationStateAsync();
            Console.WriteLine(userClaims?.User?.Identity?.IsAuthenticated);
            
			var username = userClaims?.User.Claims.FirstOrDefault(x => x.Type == "UserName");
			var user = new User(username?.Value);

            return user;
        }
    }
}