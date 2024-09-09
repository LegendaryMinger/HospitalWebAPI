using HospitalWebAPI.Interfaces;
using HospitalWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalWebAPI.Controllers
{
	[Authorize]
	[ApiController]
	[ApiExplorerSettings(GroupName = "histories")]
	[Route("/[controller]")]
	public class HistoryController : Controller
	{
		private readonly IGenericService<History> _historyService;
		public HistoryController(IGenericService<History> historyService)
		{
			_historyService = historyService;
		}
		/// <summary>
		/// Список историй болезни
		/// </summary>
		/// <remarks>Запрос для получения списка историй болезни</remarks>
		[HttpGet(nameof(GetHistories))]
		public async Task<ActionResult> GetHistories()
		{
			try
			{
				var histories = await _historyService.GetAllAsync();
				return Ok(histories);
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// История болезни
		/// </summary>
		/// <param name="id">Id истории болезни</param>
		/// <remarks>Запрос для получения истории болезни по Id</remarks>
		[HttpGet(nameof(GetHistoryById))]
		public async Task<ActionResult> GetHistoryById(int id)
		{
			try
			{
				var history = await _historyService.GetEntryByIdAsync(id);
				if (history == null)
					return NotFound();
				return Ok(history);
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Создание истории болезни
		/// </summary>
		/// <param name="history">История болезни</param>
		/// <remarks>Запрос для создания истории болезни</remarks>
		[HttpPost(nameof(CreateHistory))]
		public async Task<ActionResult> CreateHistory([FromBody] History history)
		{
			try
			{
				await _historyService.CreateEntryAsync(history);
				return Ok(await _historyService.GetEntryByIdAsync(history.Id));
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Обновление истории болезни
		/// </summary>
		/// <param name="id">Id истории болезни</param>
		/// <param name="history">История болезни</param>
		/// <remarks>Запрос для обновления истории болезни</remarks>
		[HttpPut(nameof(UpdateHistory))]
		public async Task<ActionResult> UpdateHistory(int id, [FromBody] History history)
		{
			try
			{
				if (id != history.Id)
					return BadRequest();
				await _historyService.UpdateEntryAsync(history);
				return Ok(await _historyService.GetEntryByIdAsync(history.Id));
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Удаление истории болезни
		/// </summary>
		/// <param name="id">Id истории болезни</param>
		/// <remarks>Запрос для удаления истории болезни</remarks>
		[HttpDelete(nameof(DeleteHistory))]
		public async Task<ActionResult> DeleteHistory(int id)
		{
			try
			{
				await _historyService.DeleteEntryAsync(id);
				return Ok();
			}
			catch
			{
				return StatusCode(500);
			}
		}
	}
}
