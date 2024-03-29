﻿using Microsoft.AspNetCore.Components.Authorization;
using Platender.Front.Dto;
using Platender.Front.DTO;
using Platender.Front.Helpers;
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

		public async Task<PagedData<Plate>> GetPlatesByNumbersAsync(
			string numbers,
			CultureCode? cultureCode,
			int page)
		{
			var result =  await _httpClient.GetAsync(_backendConfig.Url + "/plate" +"?"+
				"page=" + page +
				"&numbers=" + numbers +
				"&cultureCode="+ cultureCode.ToString());

			return await result.Content.ReadFromJsonAsync<PagedData<Plate>>();
		}

        public async Task<List<PlateLikeDto>> GetTopLikedPlatesAsync()
        {
			var result = await _httpClient.GetAsync(_backendConfig.Url + "/plate/top");

			return await result.Content.ReadFromJsonAsync<List<PlateLikeDto>>();
        }

        public async Task<List<CommentLikeDto>> GetTopLikedSpottsAsync()
        {
            var result = await _httpClient.GetAsync(_backendConfig.Url + "/plate/spotts/top");

            return await result.Content.ReadFromJsonAsync<List<CommentLikeDto>>();
        }

        public async Task PostPlateAsync(string numbers, CultureCode? cultureCode)
		{
			await ((ApiAuthenticationStateProvider)_authenticationStateProvider).GetAuthenticationStateAsync();

			var plate = new PlateDto(
				numbers,
				cultureCode.HasValue ? cultureCode.ToString() : null);

			var result = await _httpClient.PostAsJsonAsync(_backendConfig.Url + "/Plate", plate);
		}
	}
}
