namespace HospitalWebAPI.Models
{
	/// <summary>
	/// Модель пациента
	/// </summary>
	public class Patient
	{
		/// <summary>
		/// Уникальный идентификатор пациента
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// Уникальный идентификатор пола пациента
		/// </summary>
		public int GenderId { get; set; }
		/// <summary>
		/// Имя пациента
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Полный возраст пациента
		/// </summary>
		public int Age { get; set; }
		/// <summary>
		/// Адрес пациента
		/// </summary>
		public string Address { get; set; }
	}
}
