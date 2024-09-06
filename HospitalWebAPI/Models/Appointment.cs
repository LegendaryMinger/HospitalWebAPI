namespace HospitalWebAPI.Models
{
	/// <summary>
	/// Модель записи на прием
	/// </summary>
	public class Appointment
	{
		/// <summary>
		/// Уникальный идентификатор записи на прием
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// Уникальный идентификатор пациента, который записан на прием
		/// </summary>
		public int PatientId { get; set; }
		/// <summary>
		/// Уникальный идентификатор сотрудника, который принимает паицента
		/// </summary>
		public int EmployeeId { get; set; }
		/// <summary>
		/// Уникальный идентификатор услуги, которую предоставляют на приеме
		/// </summary>
		public int ServiceId { get; set; }
		/// <summary>
		/// Дата и время создания записи на прием
		/// </summary>
		public DateTime DateCreation { get; set; }
		/// <summary>
		/// Дата и время посещения приема
		/// </summary>
		public DateTime DateVisit { get; set; }
	} 
}
