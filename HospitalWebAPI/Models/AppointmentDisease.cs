namespace HospitalWebAPI.Models
{
	/// <summary>
	/// Модель связывающей сущности AppointmentDisease
	/// </summary>
	public class AppointmentDisease
	{
		/// <summary>
		/// Уникальный идентификатор сущности AppointmentDisease
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// Уникальный идентификатор болезни
		/// </summary>
		public int DiseaseId { get; set; }
		/// <summary>
		/// Уникальный идентификатор записи на прием
		/// </summary>
		public int AppointmentId { get; set; }
	}
}
