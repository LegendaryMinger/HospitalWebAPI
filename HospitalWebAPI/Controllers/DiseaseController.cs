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
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для получения списка болезней</remarks>
		[HttpGet(nameof(GetDiseasesAsync))]
		public async Task<ActionResult> GetDiseasesAsync(CancellationToken cancellationToken)
		{
			var diseases = await _diseaseService.GetAllAsync(cancellationToken);
			return Ok(diseases);
		}
		/// <summary>
		/// Болезнь
		/// </summary>
		/// <param name="id">Id болезни</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для получения болезни по Id</remarks>
		[HttpGet(nameof(GetDiseaseByIdAsync))]
		public async Task<ActionResult> GetDiseaseByIdAsync(int id, CancellationToken cancellationToken)
		{
			var disease = await _diseaseService.GetEntryByIdAsync(id, cancellationToken);
			return Ok(disease);
		}
		/// <summary>
		/// Создание болезни
		/// </summary>
		/// <param name="disease">Болезнь</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для создания болезни</remarks>
		[HttpPost(nameof(CreateDiseaseAsync))]
		public async Task<ActionResult> CreateDiseaseAsync([FromBody] Disease disease, CancellationToken cancellationToken)
		{
			var createdDisease = await _diseaseService.CreateEntryAsync(disease, cancellationToken);
			return Ok(createdDisease);
		}
		/// <summary>
		/// Обновление болезни
		/// </summary>
		/// <param name="id">Id болезни</param>
		/// <param name="disease">Болезнь</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для обновления болезни</remarks>
		[HttpPut(nameof(UpdateDiseaseAsync))]
		public async Task<ActionResult> UpdateDiseaseAsync(int id, [FromBody] Disease disease, CancellationToken cancellationToken)
		{
			var updatedDisease = await _diseaseService.UpdateEntryAsync(disease, cancellationToken);
			return Ok(updatedDisease);
		}
		/// <summary>
		/// Удаление болезни
		/// </summary>
		/// <param name="id">Id болезни</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для удаления болезни</remarks>
		[HttpDelete(nameof(DeleteDiseaseAsync))]
		public async Task<ActionResult> DeleteDiseaseAsync(int id, CancellationToken cancellationToken)
		{
			await _diseaseService.DeleteEntryAsync(id, cancellationToken);
			return Ok();
		}
	}
}
