namespace Platender.Core.Services
{
    public interface IUserService
    {
        Task ChangeUserAvatarAsync(byte[] avatar, string userName);
        Task AddOrRemoveUserFavouritePlate(Guid plateId, string userName);
    }
}
