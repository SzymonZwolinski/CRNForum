using Platender.Front.Dto;
using Platender.Front.DTO;
using Platender.Front.Helpers;
using Platender.Front.Models;
using Platender.Front.Models.Enums;

namespace Platender.Front.Services
{
	public interface IPlateService
	{
		Task PostPlateAsync(string numbers, CultureCode? cultureCode);
		Task<PagedData<Plate>> GetPlatesByNumbersAsync(
			string numbers,
			CultureCode? cultureCode,
			int page);
		Task<Plate> GetPlateByIdAsync(Guid id);
		Task<PagedData<Comment>> GetPlateCommentsAsync(Guid PlateId, int Page);
		Task AddCommentToPlate(CommentDto comment);
		Task<List<PlateLikeDto>> GetTopLikedPlatesAsync();
		Task<List<CommentLikeDto>> GetTopLikedSpottsAsync();
	}
}
