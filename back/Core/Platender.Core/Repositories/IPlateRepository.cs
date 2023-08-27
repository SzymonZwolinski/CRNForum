using Platender.Core.Models;

namespace Platender.Core.Repositories
{
	public interface IPlateRepository
	{
		Task AddPlateAsync(Plate plate);
		Task UpdatePlateAsync(Plate plate);
		Task<bool> CheckIfPlateExistsAsync(string number);
		Task<Plate> GetPlateAsync(Guid plateId);
		Task<Plate> GetPlateByNumbersAsync(string number);
    }
}
