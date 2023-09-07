using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platender.Application.DTO
{
	public class UserDto
	{
        public string UserName { get; set; }
        public string UserStatus { get; set; }
		public bool IsLoggedSuccesfully { get; set; }

		public UserDto(string userName, string userStatus)
        {
            UserName = userName;
			UserStatus = userStatus;
			IsLoggedSuccesfully = true;
		}
    }
}
