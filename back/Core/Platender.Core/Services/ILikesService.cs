namespace Platender.Core.Services
{
    public interface ILikesService
    {
        Task AddLikeToPlateAsync();
        Task AddDislikeToPlateAsync();
        Task AddLikeToSpottAsync();
        Task AddDislikeToSpottAsync();
    }
}
