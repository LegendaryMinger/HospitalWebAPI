namespace HospitalWebAPI.Middlewares.Exceptions
{
	public class PasswordConfirmationException : Exception
	{
		public PasswordConfirmationException(string message = null) : base(message) { }
	}
}
