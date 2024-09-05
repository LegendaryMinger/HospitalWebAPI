namespace HospitalWebAPI.Models
{
	public class AppointmentDisease
	{
		public int Id { get; set; }
		public int DiseaseId { get; set; }
		public int AppointmentId { get; set; }
	}
}
