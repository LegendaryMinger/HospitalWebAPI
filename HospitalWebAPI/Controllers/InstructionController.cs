using HospitalWebAPI.Interfaces;
using HospitalWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalWebAPI.Controllers
{
	[Authorize]
	[ApiController]
	[ApiExplorerSettings(GroupName = "instructions")]
	[Route("/[controller]")]
	public class InstructionController : Controller
	{
		private readonly IGenericService<Instruction> _instructionService;
		public InstructionController(IGenericService<Instruction> instructionService)
		{
			_instructionService = instructionService;
		}
		/// <summary>
		/// Список медицинских инструкций
		/// </summary>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для получения списка медицинских инструкций</remarks>
		[HttpGet(nameof(GetInstructionsAsync))]
		public async Task<ActionResult> GetInstructionsAsync(CancellationToken cancellationToken)
		{
			var instructions = await _instructionService.GetAllAsync(cancellationToken);
			return Ok(instructions);
		}
		/// <summary>
		/// Медицинская инструкция
		/// </summary>
		/// <param name="id">Id медицинской инструкции</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для получения медицинской инструкции по Id</remarks>
		[HttpGet(nameof(GetInstructionByIdAsync))]
		public async Task<ActionResult> GetInstructionByIdAsync(int id, CancellationToken cancellationToken)
		{
			var instruction = await _instructionService.GetEntryByIdAsync(id, cancellationToken);
			return Ok(instruction);
		}
		/// <summary>
		/// Создание медицинской инструкции
		/// </summary>
		/// <param name="instruction">Медицинская инструкция</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для создания медицинской инструкции</remarks>
		[HttpPost(nameof(CreateInstructionAsync))]
		public async Task<ActionResult> CreateInstructionAsync([FromBody] Instruction instruction, CancellationToken cancellationToken)
		{
			var createdInstruction = await _instructionService.CreateEntryAsync(instruction, cancellationToken);
			return Ok(createdInstruction);
		}
		/// <summary>
		/// Обновление медицинской инструкции
		/// </summary>
		/// <param name="id">Id медицинской инструкции</param>
		/// <param name="instruction">Медицинская инструкция</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для обновления медицинской инструкции</remarks>
		[HttpPut(nameof(UpdateInstructionAsync))]
		public async Task<ActionResult> UpdateInstructionAsync(int id, [FromBody] Instruction instruction, CancellationToken cancellationToken)
		{
			var updatedInstruction = await _instructionService.UpdateEntryAsync(instruction, cancellationToken);
			return Ok(updatedInstruction);
		}
		/// <summary>
		/// Удаление медицинской инструкции
		/// </summary>
		/// <param name="id">Id медицинской инструкции</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для удаления медицинской инструкции</remarks>
		[HttpDelete(nameof(DeleteInstructionAsync))]
		public async Task<ActionResult> DeleteInstructionAsync(int id, CancellationToken cancellationToken)
		{
			await _instructionService.DeleteEntryAsync(id, cancellationToken);
			return Ok();
		}
	}
}
