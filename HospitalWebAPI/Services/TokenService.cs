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
		public string GetToken(string login)
		{
			return _jwtConfg.GenerateToken(login);
		}
	}
}
