namespace HospitalWebAPI.Models
{
	/// <summary>
	/// Модель пола
	/// </summary>
	public class Gender
	{
		/// <summary>
		/// Уникальный идентификатор пола
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// Название пола
		/// </summary>
		public string Name { get; set; }
	}
}
