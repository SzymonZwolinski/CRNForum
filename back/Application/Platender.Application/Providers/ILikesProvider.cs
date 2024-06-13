using Platender.Application.DTO;
using Platender.Core.Helpers;

namespace Platender.Application.Providers
{
    public interface ILikesProvider
    {
        Task<IEnumerable<CommentLikeDto>> GetSpottLikeAsync();
        Task<IEnumerable<PlateLikeDto>> GetPlateLikeAsync();
        Task<PagedData<>> GetTopLikedPlates(int page, string cultureCode);
    }
}
