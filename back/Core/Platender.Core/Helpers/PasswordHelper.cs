using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Platender.Core.Helpers
{
	public static class PasswordHelper
	{
		public static void CreatePasswordHash(
			string password,
			out byte[] passwordHash,
			out byte[] passwordSalt)
		{
			using (var hmac = new HMACSHA512())
			{
				passwordSalt = hmac.Key;
				passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
			}
		}

		public static bool VerifyPasswordHash(
			string password,
			byte[] passwordHash,
			byte[] passwordSalt)
		{
			using (var hmac = new HMACSHA512(passwordSalt))
			{
				var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
				return computedHash == passwordHash;
			}
		}
	}
}
