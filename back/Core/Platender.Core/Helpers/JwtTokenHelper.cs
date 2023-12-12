using Microsoft.IdentityModel.Tokens;
using Platender.Core.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Platender.Core.Helpers
{
	public static class JwtTokenHelper
	{
		public static string CreateJWTToken(User user, string secretToken)
		{
			List<Claim> claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, user.Username)
			};
			var key = new SymmetricSecurityKey(
				System.Text.Encoding.UTF8.GetBytes(secretToken));

			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

			var token = new JwtSecurityToken(
				claims: claims,
				expires: DateTime.Now.AddDays(1),
				signingCredentials: creds);

			var jwt = new JwtSecurityTokenHandler().WriteToken(token);

			return jwt;
		}
	}
}
