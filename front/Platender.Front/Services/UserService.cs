using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Authorization;
using Platender.Front.DTO;
using Platender.Front.Helpers;
using Platender.Front.Models;
using Platender.Front.Utilities;

namespace Platender.Front.Services
{
    public class UserService : IUserService
    {
        private readonly IUserAdapter _userAdapter;
		private readonly HttpClient _httpClient;
		private readonly BackendConfig _backendConfig;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public UserService(
            IUserAdapter userAdapter,
            HttpClient httpClient,
            AuthenticationStateProvider authenticationStateProvider,
            BackendConfig backendConfig)
        {
            _userAdapter = userAdapter;
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _backendConfig = backendConfig;
        }

        public async Task AddOrRemoveUserFavouritePlateAsync(UserFavouritePlate userFavouriePlate)
        {
            await ((ApiAuthenticationStateProvider)_authenticationStateProvider).GetAuthenticationStateAsync();
            var result = await _httpClient.PostAsJsonAsync(
                _backendConfig.Url + $"/account/favourite",
                userFavouriePlate);
        }

        public async Task<User> GetAuthorizedUser()
            => await _userAdapter.AdaptBasicClaimsToUserAsync();

        public async Task<PagedData<UserFavouritePlateDto>> GetUserFavouritePlatesAsync(int page)
        {
            await ((ApiAuthenticationStateProvider)_authenticationStateProvider).GetAuthenticationStateAsync();
			var result = await _httpClient.GetAsync(
                _backendConfig.Url + $"/account/favourite?page=" + page);

            return await result.Content.ReadFromJsonAsync<PagedData<UserFavouritePlateDto>>();
        }

        public async Task UpdateUserAvatarAsync(AvatarDto avatar)
        {
            await ((ApiAuthenticationStateProvider)_authenticationStateProvider).GetAuthenticationStateAsync();
			var result = await _httpClient.PutAsJsonAsync(
                _backendConfig.Url + $"/account/avatar",
                avatar);
        }
    }
}