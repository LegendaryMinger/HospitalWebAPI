using HospitalWebAPI.Interfaces;
using HospitalWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalWebAPI.Controllers.ModelsControllers
{
	[Authorize]
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
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для получения списка полов</remarks>
		[HttpGet(nameof(GetGendersAsync))]
		public async Task<ActionResult> GetGendersAsync(CancellationToken cancellationToken)
		{
			var genders = await _genderService.GetAllAsync(cancellationToken);
			return Ok(genders);
		}
		/// <summary>
		/// Excel-отчет по полам
		/// </summary>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <returns></returns>
		/// <remarks>Запрос для получения Excel-файла по полам</remarks>
		[HttpGet(nameof(GetGendersExcelFileAsync))]
		public async Task<FileResult> GetGendersExcelFileAsync(CancellationToken cancellationToken)
		{
			var xlFile = await _genderService.GetAllExcelFileAsync(cancellationToken);
			return File(xlFile.File.ToArray(), xlFile.ContentType, xlFile.FileName);
		}
		/// <summary>
		/// Пол
		/// </summary>
		/// <param name="id">Id пола</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для получения пола по Id</remarks>
		[HttpGet(nameof(GetGenderByIdAsync))]
		public async Task<ActionResult> GetGenderByIdAsync(int id, CancellationToken cancellationToken)
		{
			var gender = await _genderService.GetEntryByIdAsync(id, cancellationToken);
			return Ok(gender);
		}
		/// <summary>
		/// Создание пола
		/// </summary>
		/// <param name="gender">Пол</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для создания пола</remarks>
		[HttpPost(nameof(CreateGenderAsync))]
		public async Task<ActionResult> CreateGenderAsync([FromBody] Gender gender, CancellationToken cancellationToken)
		{
			var createdGender = await _genderService.CreateEntryAsync(gender, cancellationToken);
			return Ok(createdGender);
		}
		/// <summary>
		/// Обновление пола
		/// </summary>
		/// <param name="gender">Пол</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для обновления пола</remarks>
		[HttpPut(nameof(UpdateGenderAsync))]
		public async Task<ActionResult> UpdateGenderAsync([FromBody] Gender gender, CancellationToken cancellationToken)
		{
			var updatedGender = await _genderService.UpdateEntryAsync(gender, cancellationToken);
			return Ok(updatedGender);
		}
		/// <summary>
		/// Удаление пола
		/// </summary>
		/// <param name="id">Id пола</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для удаления пола</remarks>
		[HttpDelete(nameof(DeleteGenderAsync))]
		public async Task<ActionResult> DeleteGenderAsync(int id, CancellationToken cancellationToken)
		{
			await _genderService.DeleteEntryAsync(id, cancellationToken);
			return Ok();
		}
	}
}
