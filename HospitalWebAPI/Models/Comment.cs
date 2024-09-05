namespace HospitalWebAPI.Models
{
	public class Comment
	{
		public int Id { get; set; }
		public int PatientId { get; set; }
		public int ServiceId { get; set; }
		public string Description { get; set; }
		public DateTime DateCreation { get; set; }
	}
}
