using HospitalWebAPI.Models;
using System.Web.Mvc;

namespace HospitalWebAPI.Interfaces
{
	public interface IUserService
	{
		Task<string> LoginAsync(string login, string password);
		Task<User> RegistrationAsync(string login, string password, string confirmPassword);
	}
}
