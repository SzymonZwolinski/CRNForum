using Platender.Application.DTO;
using Platender.Application.Messages;
using Platender.Core.Enums;

namespace Platender.Application.Providers
{
    public interface IPlateProvider
    {
        Task<IEnumerable<PlateDto>> GetPlatesAsync(string numbers, CultureCode? cultureCode);
        Task<PlateDto> GetPlateByIdAsync(Guid plateId);
		Task<Guid> AddPlateAsync(AddPlate plate);
        Task AddCommentAsync(AddComment comment, string commentingUserName);
    }
}
