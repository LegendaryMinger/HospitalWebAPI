namespace HospitalWebAPI.Models
{
	public class Instruction
	{
		public int Id { get; set; }
		public int EmployeeId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime DateCreation { get; set; }
	}
}
