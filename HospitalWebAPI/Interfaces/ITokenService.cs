namespace HospitalWebAPI.Interfaces
{
	public interface ITokenService
	{
		string GetToken(string login);
	}
}
