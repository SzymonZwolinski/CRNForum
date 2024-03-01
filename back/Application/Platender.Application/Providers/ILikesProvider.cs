using Platender.Application.DTO;

namespace Platender.Application.Providers
{
    public interface ILikesProvider
    {
        Task<IEnumerable<SpottLikeDto>> GetSpottLikeAsync();
        Task<IEnumerable<PlateLikeDto>> GetPlateLikeAsync();
    }
}
