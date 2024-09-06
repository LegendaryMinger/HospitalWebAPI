namespace HospitalWebAPI.Models
{
	/// <summary>
	/// Модель медицинской инструкции
	/// </summary>
	public class Instruction
	{
		/// <summary>
		/// Уникальный идентификатор медицинской инструкции
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// Уникальный идентификатор сотрудника, который оставил инструкцию
		/// </summary>
		public int EmployeeId { get; set; }
		/// <summary>
		/// Название медицинской инструкции
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Описание медицинской инструкции
		/// </summary>
		public string Description { get; set; }
		/// <summary>
		/// Дата и время создания медицинской инструкции
		/// </summary>
		public DateTime DateCreation { get; set; }
	}
}
