using Platender.Core.Enums;
using Platender.Core.Models;
using System.Net;

namespace Platender.Core.Services
{
	public interface IPlateService
	{
		Task<bool> CheckIfPlateExistsAsync(string number);
		Task<Plate> GetPlateAsync(Guid plateId);
		Task<(IEnumerable<Plate>, int)> GetAllPlates(
			string numbers,
			CultureCode? cultureCode, 
			int? page);
        Task<Guid> AddPlateAsync(string number, CultureCode? cultureCode);
		Task AddOrRemoveReactionToPlateAsync(
			Guid plateId,
			IPAddress userIP,
			LikeType likeType);
		Task AddOrRemoveReactionToSpottAsync(
			Guid plateId, 
			Guid spottId,
			IPAddress userIP, 
			LikeType likeType);
		Task AddSpotToPlateAsync(Guid plateId, byte[] image, string? content, string userName);
        Task<(IEnumerable<Comment>, int)> GetPlateCommentsAsync(Guid plateId, int? page);
		Task<(IEnumerable<Plate>, int)> GetFavouritePlatesAsync(int page, User user);
    }
}
