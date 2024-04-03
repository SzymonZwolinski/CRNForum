using Microsoft.AspNetCore.Components;
using Platender.Front.Components;
using Platender.Front.DTO;
using Platender.Front.Helpers;
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

		private List<Models.Comment> _comments = new();
		private int page;

		private CommentDto _comment = new CommentDto();
		private AddComment AddCommentField;

		protected override async Task OnParametersSetAsync()
		{
			var plateIdAsGuid = new Guid(plateId);

			var pagedComment = await _plateService.GetPlateCommentsAsync(plateIdAsGuid, 1);
			_comments.AddRange(pagedComment.Items);
			page = pagedComment.TotalItems / 10;

			_plate = await _plateService.GetPlateByIdAsync(plateIdAsGuid);

			StateHasChanged();
		}

		private async void PostComment()
		{
			var images = await AddCommentField.GetPostedImages();

			_comment.PlateId = _plate.Id;
			_comment.Description = AddCommentField.CommentContent;
			_comment.Image = images.FirstOrDefault();
			
			Console.WriteLine(_comment.Image);
			await _plateService.AddCommentToPlate(_comment);
		}
	}
}