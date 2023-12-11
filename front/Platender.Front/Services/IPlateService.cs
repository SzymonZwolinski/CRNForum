using Platender.Front.Models;

namespace Platender.Front.Services
{
	public interface IPlateService
	{
		Task PostPlateAsync(Plate plate);
		Task GetPlateByNumbersAsync(int numbers);
		Task<Plate> GetPlateByIdAsync(Guid id);
		Task AddCommentToPlate(int numbers, string comment);
	}
}
