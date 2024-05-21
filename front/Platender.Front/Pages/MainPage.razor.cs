using Microsoft.AspNetCore.Components;
using Platender.Front.Dto;
using Platender.Front.Models;
using Platender.Front.Services;

namespace Platender.Front.Pages
{
	public partial class MainPage
	{
		[Inject]
		private IPlateService _plateService { get; set; }

		private List<PlateLikeDto> TopLikedPlates = new();
		private List<SpottImageCarouselItem> _ImageCarouselItems = new();

		protected override async Task OnInitializedAsync()
		{
			TopLikedPlates = await _plateService.GetTopLikedPlatesAsync();

			var TopLikedSpotts = await _plateService.GetTopLikedSpottsAsync();

			_ImageCarouselItems = TopLikedSpotts.Select(x =>
				new SpottImageCarouselItem(x.PlateId, x.Byte64Image))
				.ToList();

			StateHasChanged();
		}
	}
}
