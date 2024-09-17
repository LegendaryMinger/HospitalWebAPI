namespace HospitalWebAPI.Middlewares.Exceptions
{
	public class AuthorizationException : Exception
	{
		public AuthorizationException(string message = null) : base(message) { }
	}
}
