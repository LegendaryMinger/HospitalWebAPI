namespace HospitalWebAPI.Models
{
	/// <summary>
	/// Модель медицинского сотрудника
	/// </summary>
	public class Employee
	{
		/// <summary>
		/// Уникальный идентификатор медицинского сотрудника
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// Уникальный идентификатор отделения, за которым закреплен медицинский сотрудник
		/// </summary>
		public int DepartmentId { get; set; }
		/// <summary>
		/// ФИО медицинского сотрудника
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Должность медицинского сотрудника
		/// </summary>
		public string Title { get; set; }
		/// <summary>
		/// Дата вступления в должность медицинского сотрудника
		/// </summary>
		public DateTime DateEntry { get; set; }
		/// <summary>
		/// Адрес медицинского сотрудника
		/// </summary>
		public string Address { get; set; }
	} 
}
