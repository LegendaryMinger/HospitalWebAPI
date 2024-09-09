using HospitalWebAPI.Services;
using HospitalWebAPI.Contexts;
using HospitalWebAPI.Interfaces;
using HospitalWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HospitalWebAPI.Controllers
{
	[ApiController]
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
		/// <returns></returns>
		/// <remarks>Запрос для авторизации при помощи логина и пароля</remarks>
		[HttpPost("Login")]
		[ProducesResponseType(500)]
		public async Task<ActionResult> Login(string login, string password)
		{
			try
			{
				var token = await _userService.LoginAsync(login, password);
				return Ok(new { Token = token });
			}
			catch (Exception ex)
			{
				return Unauthorized(ex.Message);
			}
		}
		/// <summary>
		/// Регистрация
		/// </summary>
		/// <param name="login">Логин</param>
		/// <param name="password">Пароль</param>
		/// <param name="confirmPassword">Подтверждение пароля</param>
		/// <returns></returns>
		/// <remarks>Запрос для регистрации при помощи логина, пароля и подтверждения пароля</remarks>
		[HttpPost("Registration")]
		[ProducesResponseType(typeof(User), 200)]
		[ProducesResponseType(409)]
		[ProducesResponseType(500)]
		public async Task<ActionResult> Registration(string login, string password, string confirmPassword)
		{
			try
			{
				var registeredUser = await _userService.RegistrationAsync(login, password, confirmPassword);
				return Ok(registeredUser);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
