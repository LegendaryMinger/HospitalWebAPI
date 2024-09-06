namespace HospitalWebAPI.Models
{
	/// <summary>
	/// Модель медицинского оборудования
	/// </summary>
	public class Equipment
	{
		/// <summary>
		/// Уникальный идентификатор медицинского оборудования
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// Уникальный идентификатор отделения, которому принадлежит медицинское оборудование
		/// </summary>
		public int DepartmentId { get; set; }
		/// <summary>
		/// Название медицинского оборудования
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Количество медицинского оборудования
		/// </summary>
		public int Count { get; set; }
	}
}
