using Platender.Application.DTO;
using Platender.Application.Mapper;
using Platender.Core.Helpers;
using Platender.Core.Models.Query;
using Platender.Core.Services;

namespace Platender.Application.Providers
{
    public class LikesProvider : ILikesProvider
    {
        private readonly ILikesService _likeService;
        private readonly IPlateService _plateService;

        public LikesProvider(ILikesService likeService, IPlateService plateService)
        {
            _likeService = likeService;
            _plateService = plateService;
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
                spott.CommentId,
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

        public async Task<PagedData<PlateDto>> GetTopLikedPlatesAsync(int page, string cultureCode)
        {
           var (plate, amount) = await _plateService.GetTopLikedPlates(page, cultureCode);

            return new PagedData<PlateDto>(plate.Select(x => x.MapToPlateDto()), amount);
        }

        public async Task<PagedData<PlateDto>> GetTopDislikedPlatesAsync(int page, string cultureCode)
        {
            var (plate, amount) = await _plateService.GetTopDislikedPlates(page, cultureCode);

            return new PagedData<PlateDto>(plate.Select(x => x.MapToPlateDto()), amount);
        }
    }
}
