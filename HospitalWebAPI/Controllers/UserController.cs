using HospitalWebAPI.Common;
using HospitalWebAPI.Contexts;
using HospitalWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
		/// <summary>
		/// Авторизация
		/// </summary>
		/// <param name="Login">Логин</param>
		/// <param name="Password">Пароль</param>
		/// <returns></returns>
		/// <remarks>Запрос для авторизации при помощи логина и пароля</remarks>
		[Route("Login")]
		[HttpPost]
		[ProducesResponseType(500)]
		public IActionResult Login(string Login, string Password)
		{
			try
			{
				if (Login == null || Password == null)
					return BadRequest();
				using (var context = new HospitalContext())
				{
					if (context.User.Any(user => user.Login == EncryptData.GetMD5Hash(Login) && user.Password == EncryptData.GetMD5Hash(Password)))
					{
						var authToken = TokenService.GenerateToken(Login);
						return Ok(new {Token = authToken});
					}
					return Unauthorized();
				}
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Регистрация
		/// </summary>
		/// <param name="Login">Логин</param>
		/// <param name="Password">Пароль</param>
		/// <param name="ConfirmPassword">Подтверждение пароля</param>
		/// <returns></returns>
		/// <remarks>Запрос для регистрации при помощи логина, пароля и подтверждения пароля</remarks>
		[Route("Registration")]
		[HttpPost]
		[ProducesResponseType(typeof(User), 200)]
		[ProducesResponseType(409)]
		[ProducesResponseType(500)]
		public IActionResult Registration(string Login, string Password, string ConfirmPassword)
		{
			try
			{
				if (Login == null || Password == null || ConfirmPassword == null)
					return BadRequest();
				if (Password != ConfirmPassword)
					return StatusCode(409);
				using (var context = new HospitalContext())
				{
					if (!context.User.Any(user => user.Login == EncryptData.GetMD5Hash(Login)))
					{
						User newUser = new User(EncryptData.GetMD5Hash(Login), EncryptData.GetMD5Hash(Password));
						context.User.Add(newUser);
						context.SaveChanges();
						return Json(newUser);
					}
					return StatusCode(409);
				}
			}
			catch
			{
				return StatusCode(500);
			}
		}
	}
}
