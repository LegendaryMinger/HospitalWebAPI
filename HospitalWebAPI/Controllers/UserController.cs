using HospitalWebAPI.Interfaces;
using HospitalWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalWebAPI.Controllers
{
	[Route("/[controller]")]
	public class UserController : Controller
	{
		private readonly IUserService _userService;
		public UserController(IUserService userService)
		{
			_userService = userService;
		}
		/// <summary>
		/// Авторизация
		/// </summary>
		/// <param name="login">Логин</param>
		/// <param name="password">Пароль</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <returns></returns>
		/// <remarks>Запрос для авторизации при помощи логина и пароля</remarks>
		[HttpPost(nameof(LoginAsync))]
		[ProducesResponseType(500)]
		public async Task<ActionResult> LoginAsync(string login, string password, CancellationToken cancellationToken)
		{
			var token = await _userService.LoginAsync(login, password, cancellationToken);
			return Ok(new { Token = token });
		}
		/// <summary>
		/// Регистрация
		/// </summary>
		/// <param name="login">Логин</param>
		/// <param name="password">Пароль</param>
		/// <param name="confirmPassword">Подтверждение пароля</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <returns></returns>
		/// <remarks>Запрос для регистрации при помощи логина, пароля и подтверждения пароля</remarks>
		[HttpPost(nameof(RegistrationAsync))]
		[ProducesResponseType(typeof(User), 200)]
		[ProducesResponseType(409)]
		[ProducesResponseType(500)]
		public async Task<ActionResult> RegistrationAsync(string login, string password, string confirmPassword, CancellationToken cancellationToken)
		{
			var registeredUser = await _userService.RegistrationAsync(login, password, confirmPassword, cancellationToken);
			return Ok(registeredUser);
		}
	}
}
