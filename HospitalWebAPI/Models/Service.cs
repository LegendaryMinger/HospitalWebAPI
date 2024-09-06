namespace HospitalWebAPI.Models
{
	/// <summary>
	/// Модель услуги
	/// </summary>
	public class Service
	{
		/// <summary>
		/// Уникальный идентификатор услуги
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// Уникальный идентификатор отделения, предоставляющего услугу
		/// </summary>
		public int DepartmentId { get; set; }
		/// <summary>
		/// Название услуги
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Цена услуги
		/// </summary>
		public double Price { get; set; }
	}
}
