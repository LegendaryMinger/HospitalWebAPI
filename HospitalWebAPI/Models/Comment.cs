namespace HospitalWebAPI.Models
{
	/// <summary>
	/// Модель отзыва
	/// </summary>
	public class Comment
	{
		/// <summary>
		/// Уникальный идентификатор отзыва
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// Уникальный идентификатор пациента, который оставил отзыв
		/// </summary>
		public int PatientId { get; set; }
		/// <summary>
		/// Уникальный идентификатор услуги, о которой оставляют отзыв
		/// </summary>
		public int ServiceId { get; set; }
		/// <summary>
		/// Описание отзыва
		/// </summary>
		public string Description { get; set; }
		/// <summary>
		/// Дата и время создания отзыва
		/// </summary>
		public DateTime DateCreation { get; set; }
	}
}
