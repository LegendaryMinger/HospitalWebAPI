namespace HospitalWebAPI.Models
{
	public class Employee
	{
		public int Id { get; set; }
		public int DepartmentId { get; set; }
		public string Name { get; set; }
		public string Title { get; set; }
		public DateTime DateEntry { get; set; }
		public string Address { get; set; }
	} 
}
