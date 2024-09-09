using HospitalWebAPI.Interfaces;
using HospitalWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalWebAPI.Controllers
{
	[Authorize]
	[ApiController]
	[ApiExplorerSettings(GroupName = "diseases")]
	[Route("/[controller]")]
	public class DiseaseController : Controller
	{
		private readonly IGenericService<Disease> _diseaseService;
		public DiseaseController(IGenericService<Disease> diseaseService)
		{
			_diseaseService = diseaseService;
		}
		/// <summary>
		/// Список болезней
		/// </summary>
		/// <remarks>Запрос для получения списка болезней</remarks>
		[HttpGet(nameof(GetDiseases))]
		public async Task<ActionResult> GetDiseases()
		{
			try
			{
				var diseases = await _diseaseService.GetAllAsync();
				return Ok(diseases);
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Болезнь
		/// </summary>
		/// <param name="id">Id болезни</param>
		/// <remarks>Запрос для получения болезни по Id</remarks>
		[HttpGet(nameof(GetDiseaseById))]
		public async Task<ActionResult> GetDiseaseById(int id)
		{
			try
			{
				var disease = await _diseaseService.GetEntryByIdAsync(id);
				if (disease == null)
					return NotFound();
				return Ok(disease);
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Создание болезни
		/// </summary>
		/// <param name="disease">Болезнь</param>
		/// <remarks>Запрос для создания болезни</remarks>
		[HttpPost(nameof(CreateDisease))]
		public async Task<ActionResult> CreateDisease([FromBody] Disease disease)
		{
			try
			{
				await _diseaseService.CreateEntryAsync(disease);
				return Ok(await _diseaseService.GetEntryByIdAsync(disease.Id));
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Обновление болезни
		/// </summary>
		/// <param name="id">Id болезни</param>
		/// <param name="disease">Болезнь</param>
		/// <remarks>Запрос для обновления болезни</remarks>
		[HttpPut(nameof(UpdateDisease))]
		public async Task<ActionResult> UpdateDisease(int id, [FromBody] Disease disease)
		{
			try
			{
				if (id != disease.Id)
					return BadRequest();
				await _diseaseService.UpdateEntryAsync(disease);
				return Ok(await _diseaseService.GetEntryByIdAsync(disease.Id));
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Удаление болезни
		/// </summary>
		/// <param name="id">Id болезни</param>
		/// <remarks>Запрос для удаления болезни</remarks>
		[HttpDelete(nameof(DeleteDisease))]
		public async Task<ActionResult> DeleteDisease(int id)
		{
			try
			{
				await _diseaseService.DeleteEntryAsync(id);
				return Ok();
			}
			catch
			{
				return StatusCode(500);
			}
		}
	}
}
