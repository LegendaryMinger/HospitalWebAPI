using HospitalWebAPI.Interfaces;
using HospitalWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalWebAPI.Controllers.ModelsControllers
{
	[Authorize]
	[ApiExplorerSettings(GroupName = "comments")]
	[Route("/[controller]")]
	public class CommentController : Controller
	{
		private readonly IGenericService<Comment> _commentService;
		public CommentController(IGenericService<Comment> commentService)
		{
			_commentService = commentService;
		}
		/// <summary>
		/// Список комментариев
		/// </summary>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для получения списка комментариев</remarks>
		[HttpGet(nameof(GetCommentsAsync))]
		public async Task<ActionResult> GetCommentsAsync(CancellationToken cancellationToken)
		{
			var comments = await _commentService.GetAllAsync(cancellationToken);
			return Ok(comments);
		}
		/// <summary>
		/// Excel-отчет по комментариям
		/// </summary>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <returns></returns>
		/// <remarks>Запрос для получения Excel-файла по комментариям</remarks>
		[HttpGet(nameof(GetCommentsExcelFileAsync))]
		public async Task<FileResult> GetCommentsExcelFileAsync(CancellationToken cancellationToken)
		{
			var xlFile = await _commentService.GetAllExcelFileAsync(cancellationToken);
			return File(xlFile.File.ToArray(), xlFile.ContentType, xlFile.FileName);
		}
		/// <summary>
		/// Комментарий
		/// </summary>
		/// <param name="id">Id комментария</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для получения комментария по Id</remarks>
		[HttpGet(nameof(GetCommentByIdAsync))]
		public async Task<ActionResult> GetCommentByIdAsync(int id, CancellationToken cancellationToken)
		{
			var comment = await _commentService.GetEntryByIdAsync(id, cancellationToken);
			return Ok(comment);
		}
		/// <summary>
		/// Создание комментария
		/// </summary>
		/// <param name="comment">Комментарий</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для создания комментария</remarks>
		[HttpPost(nameof(CreateCommentAsync))]
		public async Task<ActionResult> CreateCommentAsync([FromBody] Comment comment, CancellationToken cancellationToken)
		{
			var createdComment = await _commentService.CreateEntryAsync(comment, cancellationToken);
			return Ok(createdComment);
		}
		/// <summary>
		/// Обновление комментария
		/// </summary>
		/// <param name="comment">Комментарий</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для обновления комментария</remarks>
		[HttpPut(nameof(UpdateCommentAsync))]
		public async Task<ActionResult> UpdateCommentAsync([FromBody] Comment comment, CancellationToken cancellationToken)
		{
			var updatedComment = await _commentService.UpdateEntryAsync(comment, cancellationToken);
			return Ok(updatedComment);
		}
		/// <summary>
		/// Удаление комментария
		/// </summary>
		/// <param name="id">Id комментария</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для удаления комментария</remarks>
		[HttpDelete(nameof(DeleteCommentAsync))]
		public async Task<ActionResult> DeleteCommentAsync(int id, CancellationToken cancellationToken)
		{
			await _commentService.DeleteEntryAsync(id, cancellationToken);
			return Ok();
		}
	}
}
