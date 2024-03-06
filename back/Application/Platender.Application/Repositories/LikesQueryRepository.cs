using Microsoft.EntityFrameworkCore;
using Platender.Application.EF;
using Platender.Core.Enums;
using Platender.Core.Models.Query;
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

        public async Task<IEnumerable<PlateLikeQuery>> GetAllPlatesLikesAsync()
            => await _dbContext.Database
                .SqlQueryRaw<PlateLikeQuery>(GetAllPlateLikeQuery)
                .ToListAsync();

        public async Task<IEnumerable<SpottLikeQuery>> GetAllSpottLikesAsync()
            => await _dbContext.Database
                .SqlQueryRaw<SpottLikeQuery>(GetAllSpottsLikeQuery)
                .ToListAsync();

        private const string CreateOrReplaceSpottLikesViewQuery =
            @"CREATE OR REPLACE VIEW Top_Spotts AS
                SELECT COUNT(*) AS Count, cl.CommentId
                FROM CommentsLike cl
                JOIN Comment s ON cl.CommentId = s.Id
                WHERE cl.LikeType = 'Lik' && s.Image IS NOT NULL
                GROUP BY CommentId
                ORDER BY Count DESC
                LIMIT 10";

        private const string CreateOrReplacePlateLikesViewQuery =
            @"CREATE OR REPLACE VIEW Top_Plates AS
                SELECT COUNT(*) AS Count, PlateId
                FROM PlateLike
                WHERE LikeType = 0
                GROUP BY PlateId
                ORDER BY Count DESC
                LIMIT 10";

        private const string GetAllPlateLikeQuery =
            @"SELECT tp.Count, tp.PlateId, p.Number, p.Culture
                FROM top_plates tp
                JOIN plates p ON tp.PlateId = p.Id";

        private const string GetAllSpottsLikeQuery =
            @"SELECT ts.Count, ts.CommentId, s.PlateId, p.Number, p.Culture, s.Image, s.Description
                FROM Top_Spotts ts
                JOIN comment s ON s.Id = ts.CommentId
                JOIN plates p ON s.PlateId = p.Id;";
    }
}
