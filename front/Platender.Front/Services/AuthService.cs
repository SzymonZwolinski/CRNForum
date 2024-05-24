using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Platender.Front.DTO;
using Platender.Front.Models;
using Platender.Front.State;
using Platender.Front.Utilities;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Platender.Front.Services
{
	public class AuthService : IAuthService
	{
		private readonly HttpClient _httpClient;
		private readonly AuthenticationStateProvider _authenticationStateProvider;
		private readonly ILocalStorageService _localStorage;
		private readonly BackendConfig _backendConfig;
		private readonly IUserAdapter _userAdapter;

		public AuthService(
			HttpClient httpClient,
			AuthenticationStateProvider authenticationStateProvider,
			ILocalStorageService localStorage,
			BackendConfig backendConfig,
			IUserAdapter userAdapter)
		{
			_httpClient = httpClient;
			_authenticationStateProvider = authenticationStateProvider;
			_localStorage = localStorage;
			_backendConfig = backendConfig;
			_userAdapter = userAdapter;
		}

        public async Task ChangePasswordAsync(UserCredentialsDto userCredentialsDto)
        {
			await ((ApiAuthenticationStateProvider)_authenticationStateProvider).GetAuthenticationStateAsync();
            var result = await _httpClient.PatchAsJsonAsync(_backendConfig.Url + "/account/password", userCredentialsDto);
        }

        public async Task LoginAsync(Account loginModel)
		{
			var result = await _httpClient.PostAsJsonAsync(_backendConfig.Url + "/auth/Login", loginModel);
			if(!result.IsSuccessStatusCode)
			{
				return;
			}

			var user = await result.Content.ReadFromJsonAsync<UserDto>();

			await _localStorage.SetItemAsync("authToken", user.Token);
			((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginModel.UserName);
			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", user.Token);

			_userAdapter.AdaptUserDtoToAccountState(user);			

			return; //TODO: Add status
		}

		public async Task Logout()
		{
			await _localStorage.RemoveItemAsync("authToken");
			((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
			_httpClient.DefaultRequestHeaders.Authorization = null;

			return;
		}

		public async Task RegisterAsync(Account registerModel)
		{
			var result = await _httpClient.PostAsJsonAsync(_backendConfig.Url + "/auth/Register", registerModel);

			return;
		}
    }
}
