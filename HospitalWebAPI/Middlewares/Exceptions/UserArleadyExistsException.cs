namespace HospitalWebAPI.Middlewares.Exceptions
{
	public class UserArleadyExistsException : Exception
	{
		public UserArleadyExistsException(string message = null) : base(message) { }
	}
}
