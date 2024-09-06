using HospitalWebAPI.Common;
using HospitalWebAPI.Contexts;
using HospitalWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HospitalWebAPI.Controllers
{
	[Route("/UserController")]
	//[ApiExplorerSettings(GroupName = "v2")]
	public class UserController : Controller
	{
		private readonly HospitalContext _context;
		public UserController(HospitalContext context)
		{
			_context = context;
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
				if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
					return BadRequest();
				if (await _context.User.AnyAsync(user => user.Login == EncryptData.GetMD5Hash(login) && user.Password == EncryptData.GetMD5Hash(password)))
				{
					var authToken = TokenService.GenerateToken(login);
					return Ok(new { Token = authToken });
				}
				return Unauthorized();
			}
			catch
			{
				return StatusCode(500);
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
				if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
					return BadRequest();
				if (password != confirmPassword)
					return StatusCode(409);
				if (!await _context.User.AnyAsync(user => user.Login == EncryptData.GetMD5Hash(login)))
				{
					User newUser = new User(EncryptData.GetMD5Hash(login), EncryptData.GetMD5Hash(password));
					_context.User.Add(newUser);
					await _context.SaveChangesAsync();
					return Json(newUser);
				}
				return StatusCode(409);
			}
			catch
			{
				return StatusCode(500);
			}
		}
	}
}
