namespace HospitalWebAPI.Models
{
	/// <summary>
	/// Модель отделения
	/// </summary>
	public class Department
	{
		/// <summary>
		/// Уникальный идентификатор отделения
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// Название отделения
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Количество комнат, закрепленных за отделением
		/// </summary>
		public int CountRooms { get; set; }
		/// <summary>
		/// Адрес отделения
		/// </summary>
		public string Address { get; set; }
	} 
}
