namespace Platender.Front.Models
{
    public interface IUserAdapter
    {
        Task<User> AdaptBasicClaimsToUserAsync();
    }
}
