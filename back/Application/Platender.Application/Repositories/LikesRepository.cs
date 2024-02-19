using Platender.Application.EF;
using Platender.Core.Models;
using Platender.Core.Repositories;

namespace Platender.Application.Repositories
{
    public partial class LikesRepository : ILikesRepository
    {
        private readonly PlatenderDbContext _platenderDbContext;

        public LikesRepository(PlatenderDbContext platenderDbContext)
        {
            _platenderDbContext = platenderDbContext;
        }

        public async Task AddLikeAsync(Likes likes)
        {
            _platenderDbContext.Add(likes);
            await _platenderDbContext.SaveChangesAsync();
        }
    }
}
