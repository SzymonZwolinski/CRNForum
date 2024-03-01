using Platender.Core.Models.Query;

namespace Platender.Core.Services
{
    public interface ILikesService
    {
        Task CreateOrReplaceSpottsAndPlatesViewAsync();
        Task<IEnumerable<SpottLikeQuery>> GetTopSpottLikesAsync();
        Task<IEnumerable<PlateLikeQuery>> GetTopPlateLikesAsync();
    }
}
