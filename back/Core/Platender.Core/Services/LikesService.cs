
using Platender.Core.Models;
using Platender.Core.Repositories;

namespace Platender.Core.Services
{
    public class LikesService : ILikesService
    {
        private readonly ILikesQueryRepository _likesQueryRepository;
        private readonly ISpottsRepository _spottsRepository;

        public LikesService(ILikesQueryRepository likesQueryRepository)
        {
            _likesQueryRepository = likesQueryRepository;
        }

        public async Task CreateOrReplaceSpottsAndPlatesViewAsync()
            => await _likesQueryRepository.CreateOrReplaceSpottsAndPlatesLikesViewAsync();

        public async Task<IEnumerable<Spotts>> GetTopSpottLikesAsync()
        {
            var topLikes = await _likesQueryRepository.GetAllSpottLikesAsync();
            //TODO: Join topLikes with Spotts and return it somehow...
            
        }
    }
}
