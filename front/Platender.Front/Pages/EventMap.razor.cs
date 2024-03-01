using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Platender.Front.Services;

namespace Platender.Front.Pages
{
    public partial class EventMap : ComponentBase
    {
        private Lazy<IJSObjectReference> ExampleModule = new();
        private string? result;
        private readonly IJSRuntime js;
        [Inject]
        private IEventService _eventService { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                var raw = await _eventService.GetEventsAsync();
                
                //raw = raw.Replace('\n', ' ');

                ExampleModule = new(await JS.InvokeAsync<IJSObjectReference>("import", "./LeafletEventMap.js"));
                await ExampleModule.Value.InvokeVoidAsync("load_map", raw);
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (ExampleModule.IsValueCreated)
            {
                await ExampleModule.Value.DisposeAsync();
            }
        }
    }
}
