using HospitalWebAPI.Interfaces;
using HospitalWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalWebAPI.Controllers
{
	[Authorize]
	[ApiController]
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
		/// <remarks>Запрос для получения списка комментариев</remarks>
		[HttpGet(nameof(GetComments))]
		public async Task<ActionResult> GetComments()
		{
			try
			{
				var comments = await _commentService.GetAllAsync();
				return Ok(comments);
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Комментарий
		/// </summary>
		/// <param name="id">Id комментария</param>
		/// <remarks>Запрос для получения комментария по Id</remarks>
		[HttpGet(nameof(GetCommentById))]
		public async Task<ActionResult> GetCommentById(int id)
		{
			try
			{
				var comment = await _commentService.GetEntryByIdAsync(id);
				if (comment == null)
					return NotFound();
				return Ok(comment);
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Создание комментария
		/// </summary>
		/// <param name="comment">Комментарий</param>
		/// <remarks>Запрос для создания комментария</remarks>
		[HttpPost(nameof(CreateComment))]
		public async Task<ActionResult> CreateComment([FromBody] Comment comment)
		{
			try
			{
				await _commentService.CreateEntryAsync(comment);
				return Ok(await _commentService.GetEntryByIdAsync(comment.Id));
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Обновление комментария
		/// </summary>
		/// <param name="id">Id комментария</param>
		/// <param name="comment">Комментарий</param>
		/// <remarks>Запрос для обновления комментария</remarks>
		[HttpPut(nameof(UpdateComment))]
		public async Task<ActionResult> UpdateComment(int id, [FromBody] Comment comment)
		{
			try
			{
				if (id != comment.Id)
					return BadRequest();
				await _commentService.UpdateEntryAsync(comment);
				return Ok(await _commentService.GetEntryByIdAsync(comment.Id));
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Удаление комментария
		/// </summary>
		/// <param name="id">Id комментария</param>
		/// <remarks>Запрос для удаления комментария</remarks>
		[HttpDelete(nameof(DeleteComment))]
		public async Task<ActionResult> DeleteComment(int id)
		{
			try
			{
				await _commentService.DeleteEntryAsync(id);
				return Ok();
			}
			catch
			{
				return StatusCode(500);
			}
		}
	}
}
