using Platender.Application.DTO;
using Platender.Application.Messages;
using Platender.Core.Enums;

namespace Platender.Application.Providers
{
    public interface IPlateProvider
    {
        Task<IEnumerable<PlateDTO>> GetPlatesAsync(string numbers, CultureCode? cultureCode);
        Task<PlateDTO> GetPlateByIdAsync(Guid plateId);
		Task<Guid> AddPlateAsync(AddPlate plate);
        Task AddCommentAsync(AddComment comment, string commentingUserName);
    }
}
