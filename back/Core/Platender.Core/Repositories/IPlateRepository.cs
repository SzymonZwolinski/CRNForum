using Platender.Core.Enums;
using Platender.Core.Models;

namespace Platender.Core.Repositories
{
	public interface IPlateRepository
	{
		Task AddPlateAsync(Plate plate);
		Task UpdatePlateAsync(Plate plate);
		Task<bool> CheckIfPlateExistsAsync(string number);
		Task<Plate> GetPlateAsync(Guid plateId);
		Task<Plate> GetPlateWithLikesAsync(Guid plateId);
		Task<Plate> GetPlateWithSpottLikesAsync(Guid plateId);
		Task<(IEnumerable<Plate>, int)> GetAllPlatesAsync(
			string number,
			CultureCode? cultureCode, 
			int? page);
		Task<(IEnumerable<Comment>, int)> GetPlateCommentsAsync(Guid plateId, int? page);
		Task<(IEnumerable<Plate>, int)> GetUserFavouritePlatesAsync(int page, User user);
    }
}
