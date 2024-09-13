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
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для получения списка историй болезни</remarks>
		[HttpGet(nameof(GetHistoriesAsync))]
		public async Task<ActionResult> GetHistoriesAsync(CancellationToken cancellationToken)
		{
			var histories = await _historyService.GetAllAsync(cancellationToken);
			return Ok(histories);
		}
		/// <summary>
		/// История болезни
		/// </summary>
		/// <param name="id">Id истории болезни</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для получения истории болезни по Id</remarks>
		[HttpGet(nameof(GetHistoryByIdAsync))]
		public async Task<ActionResult> GetHistoryByIdAsync(int id, CancellationToken cancellationToken)
		{
			var history = await _historyService.GetEntryByIdAsync(id, cancellationToken);
			return Ok(history);
		}
		/// <summary>
		/// Создание истории болезни
		/// </summary>
		/// <param name="history">История болезни</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для создания истории болезни</remarks>
		[HttpPost(nameof(CreateHistoryAsync))]
		public async Task<ActionResult> CreateHistoryAsync([FromBody] History history, CancellationToken cancellationToken)
		{
			var createdHistory = await _historyService.CreateEntryAsync(history, cancellationToken);
			return Ok(createdHistory);
		}
		/// <summary>
		/// Обновление истории болезни
		/// </summary>
		/// <param name="id">Id истории болезни</param>
		/// <param name="history">История болезни</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для обновления истории болезни</remarks>
		[HttpPut(nameof(UpdateHistoryAsync))]
		public async Task<ActionResult> UpdateHistoryAsync(int id, [FromBody] History history, CancellationToken cancellationToken)
		{
			var updatedHistory = await _historyService.UpdateEntryAsync(history, cancellationToken);
			return Ok(updatedHistory);
		}
		/// <summary>
		/// Удаление истории болезни
		/// </summary>
		/// <param name="id">Id истории болезни</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для удаления истории болезни</remarks>
		[HttpDelete(nameof(DeleteHistoryAsync))]
		public async Task<ActionResult> DeleteHistoryAsync(int id, CancellationToken cancellationToken)
		{
			await _historyService.DeleteEntryAsync(id, cancellationToken);
			return Ok();
		}
	}
}
