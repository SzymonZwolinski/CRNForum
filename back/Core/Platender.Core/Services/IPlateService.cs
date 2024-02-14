using Platender.Core.Enums;
using Platender.Core.Models;

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
		Task AddCommentToPlateAsync(Guid plateId, string content, string userName);
		Task AddSpotToPlateAsync(Guid plateId, byte[] image, string content, string userName);
	}
}
