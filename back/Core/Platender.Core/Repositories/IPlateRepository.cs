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
		Task<(IEnumerable<Plate>,int)> GetAllPlatesAsync(
			string number,
			CultureCode? cultureCode, 
			int? Page);
    }
}
