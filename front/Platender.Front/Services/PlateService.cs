using Microsoft.AspNetCore.Components.Authorization;
using Platender.Front.DTO;
using Platender.Front.Models;
using Platender.Front.Models.Enums;
using Platender.Front.Utilities;
using System.Net.Http.Json;

namespace Platender.Front.Services
{
	public class PlateService : IPlateService
	{
		private readonly HttpClient _httpClient;
		private readonly BackendConfig _backendConfig;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public PlateService(BackendConfig backendConfig, 
			HttpClient httpClient,
            AuthenticationStateProvider authenticationStateProvider)
		{
			_backendConfig = backendConfig;
			_httpClient = httpClient;
			_authenticationStateProvider = authenticationStateProvider;
		}

		public async Task AddCommentToPlate(CommentDto comment)
		{
			await ((ApiAuthenticationStateProvider)_authenticationStateProvider).GetAuthenticationStateAsync();
			var result = await _httpClient.PutAsJsonAsync(
				_backendConfig.Url + $"/plate/{comment.PlateId}/comment",
				comment);
		}

		public async Task<Plate> GetPlateByIdAsync(Guid id)
		{
			var result = await _httpClient.GetAsync(_backendConfig.Url + $"/plate/{id}");
			return await result.Content.ReadFromJsonAsync<Plate>();
			
		}

		public async Task<IEnumerable<Plate>> GetPlatesByNumbersAsync(string numbers, CultureCode? cultureCode)
		{
			var result =  await _httpClient.GetAsync(_backendConfig.Url + "/plate" +"?"+
				"numbers=" + numbers +
				"&cultureCode="+ cultureCode.ToString());

			return await result.Content.ReadFromJsonAsync<IEnumerable<Plate>>();
		}

		public async Task PostPlateAsync(string numbers, CultureCode? cultureCode)
		{
			var plate = new PlateDto(numbers, cultureCode);
			var result = await _httpClient.PostAsJsonAsync(_backendConfig.Url + "/Plate", plate);
		}
	}
}
