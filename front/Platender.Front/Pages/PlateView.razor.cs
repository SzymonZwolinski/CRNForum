using Microsoft.AspNetCore.Components;
using Platender.Front.DTO;
using Platender.Front.Models;
using Platender.Front.Services;

namespace Platender.Front.Pages
{
    public partial class PlateView : ComponentBase
    {
        [Inject]
        private IPlateService _plateService { get; set; }

		[Parameter]
		public string plateId { get; set; }

		private Plate _plate = new Plate();

		private CommentDto _comment = new CommentDto();

		protected override async Task OnParametersSetAsync()
		{
			var plateIdAsGuid = new Guid(plateId);
			_plate = await _plateService.GetPlateByIdAsync(plateIdAsGuid);
		}

		private async void PostComment()
		{
			_comment.PlateId = _plate.Id;
			await _plateService.AddCommentToPlate(_comment);
		}

		private async void AddLike()
		{
			//_plateService.
		}

		private async void AddDislike()
		{

		}
	}
}