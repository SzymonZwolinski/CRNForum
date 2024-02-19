using Platender.Core.Models;

namespace Platender.Core.Repositories
{
    public interface ILikesRepository
    {
        Task AddLikeAsync(Likes likes);
    }
}
