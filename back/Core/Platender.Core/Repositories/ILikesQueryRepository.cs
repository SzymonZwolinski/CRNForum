using Platender.Core.Models.Query;

namespace Platender.Core.Repositories
{
    public interface ILikesQueryRepository
    {
        Task CreateOrReplaceSpottsAndPlatesLikesViewAsync();
        Task<IEnumerable<PlateLikeQuery>> GetAllPlatesLikesAsync();
        Task<IEnumerable<SpottLikeQuery>> GetAllSpottLikesAsync();
    }
}
