namespace HospitalWebAPI.Models
{
	public class History
	{
		public int Id { get; set; }
		public int PatientId { get; set; }
		public int EmployeeId { get; set; }
		public int DiseaseId { get; set; }
		public DateTime DateIllness { get; set; }
		public DateTime DateCure { get; set; }
		public string Description { get; set; }
	}
}
