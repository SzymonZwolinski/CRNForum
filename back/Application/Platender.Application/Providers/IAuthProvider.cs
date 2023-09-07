using Platender.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platender.Application.Providers
{
	public interface IAuthProvider
	{
		Task<UserDto> RegisterUserAsync(string userName, string password);
	}
}
