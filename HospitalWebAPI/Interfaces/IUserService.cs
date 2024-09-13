using HospitalWebAPI.Models;
using System.Web.Mvc;

namespace HospitalWebAPI.Interfaces
{
	public interface IUserService
	{
		Task<string> LoginAsync(string login, string password, CancellationToken cancellationToken);
		Task<User> RegistrationAsync(string login, string password, string confirmPassword, CancellationToken cancellationToken);
	}
}
