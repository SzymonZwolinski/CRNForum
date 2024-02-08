using Microsoft.AspNetCore.Components.Authorization;
using Platender.Front.Dto;
using Platender.Front.Utilities;
using System.Net.Http.Json;

namespace Platender.Front.Services
{
    public class EventService : IEventService
    {
        private readonly HttpClient _httpClient;
        private readonly BackendConfig _backendConfig;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public EventService(
            BackendConfig backendConfig,
            HttpClient httpClient,
            AuthenticationStateProvider authenticationStateProvider)
        {
            _backendConfig = backendConfig;
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
        }


        public async Task<IEnumerable<EventDto>> GetEventsAsync()
        {
            var result = await _httpClient.GetAsync(
                _backendConfig.Url + $"/event/all");

            return await result.Content.ReadFromJsonAsync<IEnumerable<EventDto>>();
        }
    }
}
