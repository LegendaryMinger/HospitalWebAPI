namespace HospitalWebAPI.Models
{
	/// <summary>
	/// Модель платежа
	/// </summary>
	public class Payment
	{
		/// <summary>
		/// Уникальный идентификатор платежа
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// Уникальный идентификатор оплачиваемой услуги
		/// </summary>
		public int ServiceId { get; set; }
		/// <summary>
		/// Уникальный идентификатор пациента, оплачивающего услугу
		/// </summary>
		public int PatientId { get; set; }
		/// <summary>
		/// Тип оплаты
		/// </summary>
		public string Type { get; set; }
		/// <summary>
		/// Дата и время платежа
		/// </summary>
		public DateTime DatePayment { get; set; }
	}
}
