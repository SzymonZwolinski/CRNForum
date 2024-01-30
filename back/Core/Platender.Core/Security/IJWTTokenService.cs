using Platender.Core.Models;

namespace Platender.Core.Security
{
    public interface IJWTTokenService
    {
        string GenerateToken(User user);
    }
}
