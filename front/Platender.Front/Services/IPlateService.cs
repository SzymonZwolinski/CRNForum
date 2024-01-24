using Platender.Front.Models;
using Platender.Front.Models.Enums;

namespace Platender.Front.Services
{
	public interface IPlateService
	{
		Task PostPlateAsync(string numbers, CultureCode? cultureCode);
		Task<IEnumerable<Plate>> GetPlatesByNumbersAsync(string numbers, CultureCode? cultureCode);
		Task<Plate> GetPlateByIdAsync(Guid id);
		Task AddCommentToPlate(string numbers, string comment);
	}
}
