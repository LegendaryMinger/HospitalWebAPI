namespace HospitalWebAPI.Models
{
	/// <summary>
	/// Модель истории болезни
	/// </summary>
	public class History
	{
		/// <summary>
		/// Уникальный идентификатор истории болезни
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// Уникальный идентификатор пациента, которому принадлежит история болезни
		/// </summary>
		public int PatientId { get; set; }
		/// <summary>
		/// Уникальный идентификатор лечащего врача
		/// </summary>
		public int EmployeeId { get; set; }
		/// <summary>
		/// Уникальный идентификатор болезни
		/// </summary>
		public int DiseaseId { get; set; }
		/// <summary>
		/// Дата заболевания
		/// </summary>
		public DateTime DateIllness { get; set; }
		/// <summary>
		/// Дата выздоровления
		/// </summary>
		public DateTime DateCure { get; set; }
		/// <summary>
		/// Комментарий к истории болезни
		/// </summary>
		public string Description { get; set; }
	}
}
