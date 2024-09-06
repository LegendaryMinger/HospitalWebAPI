namespace HospitalWebAPI.Interfaces
{
	public interface ITokenService
	{
		string GenerateToken(string login);
	}
}
