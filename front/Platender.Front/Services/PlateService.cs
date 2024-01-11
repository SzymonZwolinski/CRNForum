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

		public PlateService(BackendConfig backendConfig, HttpClient httpClient)
		{
			_backendConfig = backendConfig;
			_httpClient = httpClient;
		}

		public async Task AddCommentToPlate(string numbers, string comment)
		{
			var result = await _httpClient.PostAsJsonAsync(_backendConfig.Url + "/plate/" + numbers, comment);
		}

		public async Task<Plate> GetPlateByIdAsync(Guid id)
		{
			var result = await _httpClient.GetAsync(_backendConfig.Url + "/plate/" + id);
			return await result.Content.ReadFromJsonAsync<Plate>();
			
		}

		public async Task<IEnumerable<Plate>> GetPlatesByNumbersAsync(string numbers, CultureCode? cultureCode)
		{
			var result =  await _httpClient.GetAsync(_backendConfig.Url + "/plate" +
				"&numbers=" + numbers +
				"&cultureCode="+ cultureCode.ToString());

			return await result.Content.ReadFromJsonAsync<IEnumerable<Plate>>();
		}

		public async Task PostPlateAsync(Plate plate)
		{
			var result = await _httpClient.PostAsJsonAsync(_backendConfig.Url + "/plate", plate);
		}
	}
}
