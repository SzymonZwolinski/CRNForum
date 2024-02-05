using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Platender.Front.Pages
{
    public partial class EventMap : ComponentBase
    {
        private Lazy<IJSObjectReference> ExampleModule = new();
        private string? result;
        private readonly IJSRuntime js;
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                var client = new HttpClient();
                var raw = await client.GetStringAsync("https://localhost:7179/geojson.json");
                raw = raw.Replace('\n', ' ');

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
