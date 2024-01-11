using Platender.Front.Models;
using Platender.Front.Models.Enums;

namespace Platender.Front.Services
{
	public interface IPlateService
	{
		Task PostPlateAsync(Plate plate);
		Task<IEnumerable<Plate>> GetPlatesByNumbersAsync(string numbers, CultureCode? cultureCode);
		Task<Plate> GetPlateByIdAsync(Guid id);
		Task AddCommentToPlate(string numbers, string comment);
	}
}
