namespace Platender.Application.Providers
{
    public interface IUserProvider
    {
        Task ChangeUserAvatarAsync(byte[] avatar, string userName);
    }
}
