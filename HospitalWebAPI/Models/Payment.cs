namespace HospitalWebAPI.Models
{
	public class Payment
	{
		public int Id { get; set; }
		public int ServiceId { get; set; }
		public int PatientId { get; set; }
		public string Type { get; set; }
		public DateTime DatePayment { get; set; }
	}
}
