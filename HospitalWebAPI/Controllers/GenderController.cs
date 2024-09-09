using HospitalWebAPI.Interfaces;
using HospitalWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalWebAPI.Controllers
{
	[Authorize]
	[ApiController]
	[ApiExplorerSettings(GroupName = "genders")]
	[Route("/[controller]")]
	public class GenderController : Controller
	{
		private readonly IGenericService<Gender> _genderService;
		public GenderController(IGenericService<Gender> genderService)
		{
			_genderService = genderService;
		}
		/// <summary>
		/// Список полов
		/// </summary>
		/// <remarks>Запрос для получения списка полов</remarks>
		[HttpGet(nameof(GetGenders))]
		public async Task<ActionResult> GetGenders()
		{
			try
			{
				var genders = await _genderService.GetAllAsync();
				return Ok(genders);
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Пол
		/// </summary>
		/// <param name="id">Id пола</param>
		/// <remarks>Запрос для получения пола по Id</remarks>
		[HttpGet(nameof(GetGenderById))]
		public async Task<ActionResult> GetGenderById(int id)
		{
			try
			{
				var gender = await _genderService.GetEntryByIdAsync(id);
				if (gender == null)
					return NotFound();
				return Ok(gender);
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Создание пола
		/// </summary>
		/// <param name="gender">Пол</param>
		/// <remarks>Запрос для создания пола</remarks>
		[HttpPost(nameof(CreateGender))]
		public async Task<ActionResult> CreateGender([FromBody] Gender gender)
		{
			try
			{
				await _genderService.CreateEntryAsync(gender);
				return Ok(await _genderService.GetEntryByIdAsync(gender.Id));
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Обновление пола
		/// </summary>
		/// <param name="id">Id пола</param>
		/// <param name="gender">Пол</param>
		/// <remarks>Запрос для обновления пола</remarks>
		[HttpPut(nameof(UpdateGender))]
		public async Task<ActionResult> UpdateGender(int id, [FromBody] Gender gender)
		{
			try
			{
				if (id != gender.Id)
					return BadRequest();
				await _genderService.UpdateEntryAsync(gender);
				return Ok(await _genderService.GetEntryByIdAsync(gender.Id));
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Удаление пола
		/// </summary>
		/// <param name="id">Id пола</param>
		/// <remarks>Запрос для удаления пола</remarks>
		[HttpDelete(nameof(DeleteGender))]
		public async Task<ActionResult> DeleteGender(int id)
		{
			try
			{
				await _genderService.DeleteEntryAsync(id);
				return Ok();
			}
			catch
			{
				return StatusCode(500);
			}
		}
	}
}
