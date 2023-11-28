using Platender.Core.Models;
using Platender.Core.Repositories;

namespace Platender.Application.Repositories
{
	public class AuthRepository : IAuthRepository
	{
		private List<User> _users = new List<User>();// TODO: Change this after sql

		public Task CreateUserAsync(User user)
		{
			_users.Add(user);
			return Task.CompletedTask;
		}

		public Task<User> GetUserAsync(string userName)
		{
			var user = _users.FirstOrDefault(x =>
			x.Username.Equals(userName, StringComparison.Ordinal));

			if (user == null) 
			{
				throw new ArgumentException($"User with name: {userName} does not exists");
			}

			return Task.FromResult(user);
		}
	}
}
