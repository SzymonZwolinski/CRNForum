namespace Platender.Core.Services
{
    public interface IUserService
    {
        Task ChangeUserAvatarAsync(byte[] avatar, string userName);
    }
}
