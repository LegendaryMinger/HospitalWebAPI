namespace HospitalWebAPI.Models
{
	/// <summary>
	/// Модель пользователя
	/// </summary>
	public class User
	{
		/// <summary>
		/// Уникальный идентификатор пользователя
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// Логин пользователя
		/// </summary>
		public string Login {  get; set; }
		/// <summary>
		/// Пароль пользователя
		/// </summary>
		public string Password { get; set; }
	}
}
