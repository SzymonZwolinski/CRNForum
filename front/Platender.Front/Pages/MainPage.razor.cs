
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Platender.Front.Dto;
using Platender.Front.Services;

namespace Platender.Front.Pages
{
		public partial class MainPage
		{
			[Inject]
			private IPlateService _plateService { get; set; }

			private List<string> BestDrivers = new();
			private IList<string> _source = new List<string>() { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5" };
			private List<PlateLikeDto> TopLikedPlates = new();
			private	List<CommentLikeDto> TopLikedSpotts = new();

			protected override async Task OnParametersSetAsync()
			{
				TopLikedPlates = await _plateService.GetTopLikedPlatesAsync();

				TopLikedSpotts = await _plateService.GetTopLikedSpottsAsync();
				StateHasChanged();
			}
		}
}
