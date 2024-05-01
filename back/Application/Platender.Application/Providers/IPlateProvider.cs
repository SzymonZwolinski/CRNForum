using Platender.Application.DTO;
using Platender.Application.Messages;
using Platender.Application.Messages.Queries;
using Platender.Core.Helpers;
using System.Net;

namespace Platender.Application.Providers
{
    public interface IPlateProvider
    {
        Task<PagedData<PlateDto>> GetPlatesAsync(GetAllPlates getAllPlates, IPAddress userIp);
        Task<PlateDto> GetPlateByIdAsync(Guid plateId, IPAddress userIp);
		Task<Guid> AddPlateAsync(AddPlate plate);
        Task AddOrRemoveReactionToPlateAsync(AddReaction plateLike, IPAddress userIpAddress);
        Task AddSpotAsync(AddComment plate, string commentingUserName);
        Task<PagedData<CommentDto>> GetPlateCommentsAsync(Guid plateId, int? page, IPAddress userIpAddress);
        Task AddOrRemoveReactionToSpottAsync(AddReaction spottLike, IPAddress userIpAddress);
    }
}
