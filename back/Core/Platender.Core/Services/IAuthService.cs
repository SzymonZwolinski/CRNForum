using Platender.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platender.Core.Services
{
	public interface IAuthService
	{
		Task<User> CreateUserAsync(
			string userName, 
			byte[] passwordHash,
			byte[] passwordSalt);
	}
}
