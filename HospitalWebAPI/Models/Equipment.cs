namespace HospitalWebAPI.Models
{
	public class Equipment
	{
		public int Id { get; set; }
		public int DepartmentId { get; set; }
		public string Name { get; set; }
		public int Count { get; set; }
	}
}
