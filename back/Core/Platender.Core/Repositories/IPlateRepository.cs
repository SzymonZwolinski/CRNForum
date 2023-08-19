using Platender.Core.Models;

namespace Platender.Core.Repositories
{
	public interface IPlateRepository
	{
		Task AddPlateAsync(Plate plate);
		Task UpdatePlateAsync(Plate plate);
		Task CheckIfPlateExistsAsync(Guid plateId);
		Task<Plate> GetPlateAsync(Guid plateId);
	}
}
