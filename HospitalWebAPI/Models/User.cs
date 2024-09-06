namespace HospitalWebAPI.Models
{
	public class User
	{
		public int Id { get; set; }
		public string Login {  get; set; }
		public string Password { get; set; }
		public User(string Login, string Password)
		{
			this.Login = Login;
			this.Password = Password;
		}
	}
}
