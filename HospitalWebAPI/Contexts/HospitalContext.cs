using HospitalWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalWebAPI.Contexts
{
	public class HospitalContext : DbContext
	{
		public HospitalContext(DbContextOptions<HospitalContext> options) : base(options) { }
		public DbSet<Appointment> Appointment { get; set; }
		public DbSet<AppointmentDisease> AppointmentDisease { get; set; }
		public DbSet<Comment> Comment { get; set; }
		public DbSet<Department> Department { get; set; }
		public DbSet<Disease> Disease { get; set; }
		public DbSet<Employee> Employee { get; set; }
		public DbSet<Equipment> Equipment { get; set; }
		public DbSet<Gender> Gender { get; set; }
		public DbSet<History> History { get; set; }
		public DbSet<Instruction> Instruction { get; set; }
		public DbSet<Patient> Patient { get; set; }
		public DbSet<Payment> Payment { get; set; }
		public DbSet<Service> Service { get; set; }
		public DbSet<User> User { get; set; }
	}
}
