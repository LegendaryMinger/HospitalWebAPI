namespace HospitalWebAPI.Models
{
	public class Appointment
	{
		public int Id { get; set; }
		public int PatientId { get; set; }
		public int EmployeeId { get; set; }
		public int ServiceId { get; set; }
		public DateTime DateCreation { get; set; }
		public DateTime DateVisit { get; set; }
	} 
}
