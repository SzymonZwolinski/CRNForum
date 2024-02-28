using Platender.Application.DTO;
using Platender.Application.Messages;
using Platender.Application.Messages.Queries;
using Platender.Core.Helpers;
using System.Net;

namespace Platender.Application.Providers
{
    public interface IPlateProvider
    {
        Task<PagedData<PlateDto>> GetPlatesAsync(GetAllPlates getAllPlates);
        Task<PlateDto> GetPlateByIdAsync(Guid plateId);
		Task<Guid> AddPlateAsync(AddPlate plate);
        Task AddOrRemoveReactionToPlateAsync(AddReaction plateLike, IPAddress userIpAddress);
        Task AddCommentAsync(AddComment comment, string commentingUserName);
        Task AddSpotAsync(AddSpot plate, string commentingUserName);
        Task<PagedData<CommentDto>> GetPlateCommentsAsync(Guid plateId, int? page);
        Task<PagedData<SpottDto>> GetPlateSpottsAsync(Guid plateId, int? page);
        Task AddOrRemoveReactionToSpottAsync(AddReaction spottLike, IPAddress userIpAddress);
    }
}
