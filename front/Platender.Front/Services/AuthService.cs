using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Platender.Front.Models;
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

		public AuthService(HttpClient httpClient,
					   AuthenticationStateProvider authenticationStateProvider,
					   ILocalStorageService localStorage,
					   BackendConfig backendConfig)
		{
			_httpClient = httpClient;
			_authenticationStateProvider = authenticationStateProvider;
			_localStorage = localStorage;
			_backendConfig = backendConfig;
		}

		public async Task LoginAsync(Account loginModel)
		{
			var result = await _httpClient.PostAsJsonAsync(_backendConfig.Url + "/auth/Login", loginModel);
			
			if(!result.IsSuccessStatusCode)
			{
				return;
			}

			var token = await result.Content.ReadAsStringAsync();

			await _localStorage.SetItemAsync("authToken", token);
			((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginModel.UserName);
			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
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
