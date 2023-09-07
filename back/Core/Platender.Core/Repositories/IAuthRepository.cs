using Platender.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platender.Core.Repositories
{
	public interface IAuthRepository
	{
		Task CreateUserAsync(User user);
	}
}
