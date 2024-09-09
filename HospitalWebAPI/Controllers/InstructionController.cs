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
		/// <remarks>Запрос для получения списка медицинских инструкций</remarks>
		[HttpGet(nameof(GetInstructions))]
		public async Task<ActionResult> GetInstructions()
		{
			try
			{
				var instructions = await _instructionService.GetAllAsync();
				return Ok(instructions);
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Медицинская инструкция
		/// </summary>
		/// <param name="id">Id медицинской инструкции</param>
		/// <remarks>Запрос для получения медицинской инструкции по Id</remarks>
		[HttpGet(nameof(GetInstructionById))]
		public async Task<ActionResult> GetInstructionById(int id)
		{
			try
			{
				var instruction = await _instructionService.GetEntryByIdAsync(id);
				if (instruction == null)
					return NotFound();
				return Ok(instruction);
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Создание медицинской инструкции
		/// </summary>
		/// <param name="instruction">Медицинская инструкция</param>
		/// <remarks>Запрос для создания медицинской инструкции</remarks>
		[HttpPost(nameof(CreateInstruction))]
		public async Task<ActionResult> CreateInstruction([FromBody] Instruction instruction)
		{
			try
			{
				await _instructionService.CreateEntryAsync(instruction);
				return Ok(await _instructionService.GetEntryByIdAsync(instruction.Id));
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Обновление медицинской инструкции
		/// </summary>
		/// <param name="id">Id медицинской инструкции</param>
		/// <param name="instruction">Медицинская инструкция</param>
		/// <remarks>Запрос для обновления медицинской инструкции</remarks>
		[HttpPut(nameof(UpdateInstruction))]
		public async Task<ActionResult> UpdateInstruction(int id, [FromBody] Instruction instruction)
		{
			try
			{
				if (id != instruction.Id)
					return BadRequest();
				await _instructionService.UpdateEntryAsync(instruction);
				return Ok(await _instructionService.GetEntryByIdAsync(instruction.Id));
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Удаление медицинской инструкции
		/// </summary>
		/// <param name="id">Id медицинской инструкции</param>
		/// <remarks>Запрос для удаления медицинской инструкции</remarks>
		[HttpDelete(nameof(DeleteInstruction))]
		public async Task<ActionResult> DeleteInstruction(int id)
		{
			try
			{
				await _instructionService.DeleteEntryAsync(id);
				return Ok();
			}
			catch
			{
				return StatusCode(500);
			}
		}
	}
}
