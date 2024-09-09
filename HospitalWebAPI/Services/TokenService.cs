using HospitalWebAPI.Classes;
using HospitalWebAPI.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HospitalWebAPI.Services
{
	public class TokenService : ITokenService
	{
		private readonly JwtConfig _jwtConfg;
		public TokenService(IOptions<JwtConfig> jwtConfig)
		{
			_jwtConfg = jwtConfig.Value;
		}
		public string GenerateToken(string login)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_jwtConfg.Key);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
				new Claim(ClaimTypes.Name, login)
				}),
				Expires = DateTime.UtcNow.AddHours(1),
				Issuer = _jwtConfg.Issuer,
				Audience = _jwtConfg.Audience,
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
	}
}
