using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HospitalWebAPI.Common
{
	public class TokenService
	{
		public const string JwtKey = "c93624fe39530ce8e5b18950d61015e13d5393696263dae942f130afced6c419";
		public const string JwtIssuer = "https://domainfortoken.com";
		public const string JwtAudience = "https://domainfortoken.com";
		public static string GenerateToken(string login)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(JwtKey);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
				new Claim(ClaimTypes.Name, login)
				}),
				Expires = DateTime.UtcNow.AddHours(1),
				Issuer = JwtIssuer,
				Audience = JwtAudience,
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
	}
}
