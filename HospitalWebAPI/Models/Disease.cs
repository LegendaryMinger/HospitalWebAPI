namespace HospitalWebAPI.Models
{
	/// <summary>
	/// Модель болезни
	/// </summary>
	public class Disease
	{
		/// <summary>
		/// Уникальный идентификатор болезни
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// Название болезни
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Симптомы болезни
		/// </summary>
		public string Symptoms { get; set; }
		/// <summary>
		/// Медицинские показания к болезни
		/// </summary>
		public string Indications { get; set; }
	}
}
