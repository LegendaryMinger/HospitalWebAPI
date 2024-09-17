namespace HospitalWebAPI.Middlewares.Exceptions
{
    public class EntryIsNullException : Exception
    {
		public EntryIsNullException(string message = null) : base(message) { }
	}
}
