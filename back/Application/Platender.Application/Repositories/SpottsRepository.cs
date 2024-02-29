using Microsoft.EntityFrameworkCore;
using Platender.Application.EF;
using Platender.Core.Models;
using Platender.Core.Repositories;

namespace Platender.Application.Repositories
{
    public class SpottsRepository : ISpottsRepository
    {
        private readonly PlatenderDbContext _dBContext;

        public SpottsRepository(PlatenderDbContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<IEnumerable<Spotts>> GetSpottsAsync(List<Guid> SpottIds)
            => await _dBContext.spotts.Where(x => SpottIds.Contains(x.Id)).ToListAsync();
    }
}
