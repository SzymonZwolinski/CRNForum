using Platender.Application.DTO;
using Platender.Core.Models.Query;
using Platender.Core.Services;

namespace Platender.Application.Providers
{
    public class LikesProvider : ILikesProvider
    {
        private readonly ILikesService _likeService;

        public LikesProvider(ILikesService likeService)
        {
            _likeService = likeService;
        }

        public async Task<IEnumerable<PlateLikeDto>> GetPlateLikeAsync()
        {
            var plates = await _likeService.GetTopPlateLikesAsync();

            return plates.Select(x => MapToPlateLikeDto(x));
        }

        public async Task<IEnumerable<CommentLikeDto>> GetSpottLikeAsync()
        {
            var spotts = await _likeService.GetTopSpottLikesAsync();

            return spotts.Select(x => MapToSpottLikeDto(x));
        }

        private CommentLikeDto MapToSpottLikeDto(SpottLikeQuery spott)
            => new CommentLikeDto(
                spott.Count, 
                spott.SpottId,
                spott.PlateId, 
                spott.Number,
                spott.Culture,
                spott.Image,
                spott.Description);

        private PlateLikeDto MapToPlateLikeDto(PlateLikeQuery plate)
            => new PlateLikeDto(
                plate.Count,
                plate.PlateId,
                plate.Number,
                plate.Culture);
    }
}
