using System.Text.Json;

namespace HospitalWebAPI.Classes
{
	public class ErrorDataTranferObject
	{
		public int StatusCode { get; set; }
		public string Message { get; set; }
	}
}
