using Platender.Application.DTO;
using Platender.Application.Messages;
using Platender.Application.Messages.Queries;
using Platender.Core.Helpers;

namespace Platender.Application.Providers
{
    public interface IPlateProvider
    {
        Task<PagedData<PlateDto>> GetPlatesAsync(GetAllPlates getAllPlates);
        Task<PlateDto> GetPlateByIdAsync(Guid plateId);
		Task<Guid> AddPlateAsync(AddPlate plate);
        Task AddCommentAsync(AddComment comment, string commentingUserName);
        Task AddSpotAsync(AddSpot plate, string commentingUserName);
    }
}
