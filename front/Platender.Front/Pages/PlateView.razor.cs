using Microsoft.AspNetCore.Components;
using Platender.Front.Components;
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
		private List<Models.Comment> _comments = new();
		private int page = 1;
		private int MaxPage;

		private CommentDto _comment = new CommentDto();
		private AddComment AddCommentField;

		private bool IsCommentSent = false;

		protected override async Task OnParametersSetAsync()
		{
			var plateIdAsGuid = new Guid(plateId);
			var pagedComment = await _plateService.GetPlateCommentsAsync(plateIdAsGuid, page);
			_comments.AddRange(pagedComment.Items);
			//GetPlate comments gets 10 comments per request (page)
			MaxPage = (pagedComment.TotalItems + 9) / 10;
			page++;

			_plate = await _plateService.GetPlateByIdAsync(plateIdAsGuid);
			
			StateHasChanged();
		}

		private async void PostComment()
		{
			var images = await AddCommentField.GetPostedImages();
			
			_comment.PlateId = _plate.Id;
			_comment.Description = AddCommentField.CommentContent;
			_comment.Image = images.FirstOrDefault();

			if(string.IsNullOrWhiteSpace(_comment.Description))
			{
				if(_comment.Image is null)
				{
					return;
					//SHOW ERROR IF NULL!
				}
			}
			
			await _plateService.AddCommentToPlate(_comment);
			
			_comments.Insert(0,
				new Models.Comment(
					_comment.Description, 
					AddCommentField.CurrentUser.Username,
				 	_comment.Image, DateTime.Now));

			IsCommentSent = true;
			StateHasChanged();
		}

		public async Task AddOrRemoveLikeToCommentAsync(Guid commentId)
		{
			await _plateService.AddLikeToCommentAsync(new Guid(plateId), commentId);
		}

		public async Task AddOrRemoveDislikeToCommentAsync(Guid commentId)
		{
			await _plateService.AddDislikeToCommentAsync(new Guid(plateId), commentId);	
		}

		public async Task AddOrRemoveLikeToPlateAsync()
		{
			await _plateService.AddLikeToPlateAsync(new Guid(plateId));
		}

		public async Task AddOrRemoveDislikeToPlateAsync()
		{
			await _plateService.AddDislikeToPlateAsync(new Guid(plateId));
		}

		private async Task HandleEndOfInfinityLoad()
		{
			if(page > MaxPage)
			{
				return;
			}

			await LoadNewCommentsAsync();
			
			StateHasChanged();
		}

		private async Task LoadNewCommentsAsync()
		{
			var pagedComment = await _plateService.GetPlateCommentsAsync(new Guid(plateId), page);
			
			_comments.AddRange(pagedComment.Items);
			page++;
		}
	}
}