using Platender.Core.Models;

namespace Platender.Core.Repositories
{
    public interface ILikesQueryRepository
    {
        Task CreateOrReplaceSpottsAndPlatesLikesViewAsync();
        Task<IEnumerable<PlateLike>> GetAllPlatesLikesAsync();
        Task<IEnumerable<SpottLike>> GetAllSpottLikesAsync();
    }
}
