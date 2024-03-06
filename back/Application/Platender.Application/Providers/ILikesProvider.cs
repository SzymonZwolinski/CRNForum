using Platender.Application.DTO;

namespace Platender.Application.Providers
{
    public interface ILikesProvider
    {
        Task<IEnumerable<CommentLikeDto>> GetSpottLikeAsync();
        Task<IEnumerable<PlateLikeDto>> GetPlateLikeAsync();
    }
}
