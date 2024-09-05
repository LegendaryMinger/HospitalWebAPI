namespace HospitalWebAPI.Models
{
	public class Service
	{
		public int Id { get; set; }
		public int DepartmentId { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
	}
}
