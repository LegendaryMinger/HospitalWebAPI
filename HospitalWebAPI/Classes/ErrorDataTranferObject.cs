using System.Text.Json;

namespace HospitalWebAPI.Classes
{
	public class ErrorDataTranferObject
	{
		public int StatusCode { get; set; }
		public string Message { get; set; }

		public override string ToString()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}
