using Microsoft.EntityFrameworkCore;
using Platender.Application.EF;
using Platender.Core.Models;
using Platender.Core.Repositories;

namespace Platender.Application.Repositories
{
    public class LikesQueryRepository : ILikesQueryRepository
    {
        private readonly PlatenderDbContext _dbContext;

        public LikesQueryRepository(PlatenderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateOrReplaceSpottsAndPlatesLikesViewAsync()
        {
            await _dbContext.Database.ExecuteSqlRawAsync(CreateOrReplaceSpottLikesViewQuery);
            await _dbContext.Database.ExecuteSqlRawAsync(CreateOrReplacePlateLikesViewQuery);
        }

        public async Task<IEnumerable<PlateLike>> GetAllPlatesLikesAsync()
            => await _dbContext.Set<PlateLike>()
                .FromSqlRaw(GetAllPlateLikeQuery)
                .ToListAsync();

        public async Task<IEnumerable<SpottLike>> GetAllSpottLikesAsync()
            => await _dbContext.Set<SpottLike>()
                .FromSqlRaw(GetAllSpottsLikeQuery)
                .ToListAsync();

        private const string CreateOrReplaceSpottLikesViewQuery =
            @"CREATE OR REPLACE VIEW Top_Spotts AS
                SELECT COUNT(*) AS Count, SpottId
                FROM spottlike
                WHERE LikeType = 'lik'
                GROUP BY SpottId
                ORDER BY Count DESC
                LIMIT 10";

        private const string CreateOrReplacePlateLikesViewQuery =
            @"CREATE OR REPLACE VIEW Top_Plates AS
                SELECT COUNT(*) AS Count, PlateId
                FROM platelike
                WHERE LikeType = 'lik'
                GROUP BY PlateId
                ORDER BY Count DESC
                LIMIT 10";

        private const string GetAllPlateLikeQuery =
            @"SELECT Count, PlateId
                FROM Top_Plates";

        private const string GetAllSpottsLikeQuery =
            @"Select Count, SpottId
                From Top_Plates";
    }
}
