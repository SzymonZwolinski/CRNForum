using Microsoft.EntityFrameworkCore;
using Platender.Application.EF;
using Platender.Core.Models;
using Platender.Core.Repositories;

namespace Platender.Application.Repositories
{
    public class AuthRepository : IAuthRepository
	{
        private readonly PlatenderDbContext _platenderDbContext;

        public AuthRepository(PlatenderDbContext platenderDbContext)
        {
            _platenderDbContext = platenderDbContext;
        }

        public async Task CreateUserAsync(User user)
		{
            await _platenderDbContext.AddAsync(user);
			await _platenderDbContext.SaveChangesAsync();
		}

		public async Task<User> GetUserAsync(string userName)
		{
            var users = await _platenderDbContext
                 .users
                 .Include(x => x.EventUsers)
                 .Where(x => x.Username.Equals(userName))
                 .ToListAsync();

            return users.FirstOrDefault(x => string.Compare(
                x.Username, 
                userName,
                StringComparison.Ordinal) == 0);
        }

        public async Task UpdateUserAsync(User user)
        {
            _platenderDbContext.Update(user);

            await _platenderDbContext.SaveChangesAsync();
        }
    }
}
