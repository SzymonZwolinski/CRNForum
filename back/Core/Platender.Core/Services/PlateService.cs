
using Platender.Core.Models;
using Platender.Core.Repositories;

namespace Platender.Core.Services
{
	public class PlateService : IPlateService
	{
		private readonly IPlateRepository _plateRepository;

		public PlateService(IPlateRepository plateRepository)
		{
			_plateRepository = plateRepository;
		}

		public async Task AddCommentToPlateAsync(Guid plateId, string content, string userName)
		{
			var plate = await _plateRepository.GetPlateAsync(plateId);
			var comment = CreateComment(plate, content, userName);

			plate.AddComment(comment);

			await _plateRepository.UpdatePlateAsync(plate);
		}

		private Comment CreateComment(Plate plate, string content, string userName)
		{
			return new Comment(
				content,
				userName,
				plate.Comments
				.OrderBy(x => x.Sequence)
				.First()
				.Sequence + 1);
		}

		public void AddDislikeToCommentInPlate(Guid plateId, Guid commentId)
		{
			throw new NotImplementedException();
		}

		public void AddLikeToCommentInPlate(Guid plateId, Guid commentId)
		{
			throw new NotImplementedException();
		}

		public void AddLikeToPlate(Guid plateId)
		{
			throw new NotImplementedException();
		}

		public void AddPlate(string number)
		{
			throw new NotImplementedException();
		}

		public bool CheckIfPlateExists(string number)
		{
			throw new NotImplementedException();
		}

		public void RemoveDislikeToCommentInPlate(Guid plateId, Guid commentId)
		{
			throw new NotImplementedException();
		}

		public void RemoveLikeFromCommentInPlate(Guid plateId, Guid commentId)
		{
			throw new NotImplementedException();
		}

		public void RemoveLikeFromPlate(Guid plateId)
		{
			throw new NotImplementedException();
		}
	}
}
