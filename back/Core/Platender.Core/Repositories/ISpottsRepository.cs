using Platender.Core.Models;

namespace Platender.Core.Repositories
{
    public interface ISpottsRepository
    {
        Task<IEnumerable<Spotts>> GetSpottsAsync(List<Guid> SpottId);
    }
}
