using Microsoft.IdentityModel.Tokens;
using Platender.Core.Models;
using Platender.Core.Security;
using Platender.Infrastructure.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Platender.Infrastructure.Security
{
    public class JWTTokenService : IJWTTokenService
    {
        private readonly TokenSettings _tokenSettings;

        public JWTTokenService(TokenSettings tokenSettings)
        {
            _tokenSettings = tokenSettings;
        }

        public string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_tokenSettings.SigningKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var expiry = DateTimeOffset.Now.AddMinutes(15);
            var userClaims = GetClaimsForUser(user);

            var securityToken = new JwtSecurityToken(
                issuer: _tokenSettings.Issuer,
                audience: _tokenSettings.Audience,
                claims: userClaims,
                notBefore: DateTime.Now,
                expires: expiry.DateTime,
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }

        private IEnumerable<Claim> GetClaimsForUser(User user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim("UserName", user.Username));

            return claims;
        }
    }
}
