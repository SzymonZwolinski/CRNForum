using Platender.Application.DTO;
using Platender.Core.Helpers;

namespace Platender.Application.Providers
{
    public interface ILikesProvider
    {
        Task<IEnumerable<CommentLikeDto>> GetSpottLikeAsync();
        Task<IEnumerable<PlateLikeDto>> GetPlateLikeAsync();
        Task<PagedData<PlateDto>> GetTopLikedPlatesAsync(int page, string cultureCode);
        Task<PagedData<PlateDto>> GetTopDislikedPlatesAsync(int page, string cultureCode);
    }
}
