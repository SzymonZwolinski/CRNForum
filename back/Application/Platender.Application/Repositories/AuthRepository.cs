using Platender.Core.Models;
using Platender.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
	}
}
