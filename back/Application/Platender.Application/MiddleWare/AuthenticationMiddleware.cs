using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Platender.Application.MiddleWare
{
	public class AuthenticationMiddleware
	{
		private readonly RequestDelegate _next;

		// Dependency Injection
		public AuthenticationMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context)
		{
			string authHeader = context.Request.Headers["Authorization"];

			if (authHeader != null)
			{
			       
				int startPoint = authHeader.IndexOf(".") + 1;
				int endPoint = authHeader.LastIndexOf(".");

				var tokenString = authHeader
					.Substring(startPoint, endPoint - startPoint).Split(".");
				var token = tokenString[0].ToString() + "==";

				var credentialString = Encoding.UTF8
					.GetString(Convert.FromBase64String(token));

				var credentials = credentialString.Split(new char[] { ':', ',' });

				var userName = credentials[3].Replace("\"", "");

				var claims = new[]
				{
			   new Claim(ClaimTypes.Name, userName),
				};
				var identity = new ClaimsIdentity(claims, "basic");
				context.User = new ClaimsPrincipal(identity);
			}
			//Pass to the next middleware
			await _next(context);
		}
	}
}
