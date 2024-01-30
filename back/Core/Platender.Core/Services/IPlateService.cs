using Platender.Core.Enums;
using Platender.Core.Models;

namespace Platender.Core.Services
{
	public interface IPlateService
	{
		Task<bool> CheckIfPlateExistsAsync(string number);
		Task<Plate> GetPlateAsync(Guid plateId);
        Task<IEnumerable<Plate>> GetPlatesByNumbers(string numbers, CultureCode? cultureCode);
        Task<Guid> AddPlateAsync(string number, CultureCode? cultureCode);
		Task AddCommentToPlateAsync(Guid plateId, string content, string userName);
	}
}
