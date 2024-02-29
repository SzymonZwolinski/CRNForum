using Platender.Core.Models;

namespace Platender.Core.Services
{
    public interface ILikesService
    {
        Task CreateOrReplaceSpottsAndPlatesViewAsync();
        Task<IEnumerable<Spotts>> GetTopSpottLikesAsync();
    }
}
