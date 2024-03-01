
using Platender.Core.Models.Query;
using Platender.Core.Repositories;

namespace Platender.Core.Services
{
    public class LikesService : ILikesService
    {
        private readonly ILikesQueryRepository _likesQueryRepository;

        public LikesService(ILikesQueryRepository likesQueryRepository)
        {
            _likesQueryRepository = likesQueryRepository;
        }

        public async Task CreateOrReplaceSpottsAndPlatesViewAsync()
            => await _likesQueryRepository.CreateOrReplaceSpottsAndPlatesLikesViewAsync();

        public async Task<IEnumerable<PlateLikeQuery>> GetTopPlateLikesAsync()
            => await _likesQueryRepository.GetAllPlatesLikesAsync();

        public async Task<IEnumerable<SpottLikeQuery>> GetTopSpottLikesAsync()
            => await _likesQueryRepository.GetAllSpottLikesAsync();
    }
}
