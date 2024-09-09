using HospitalWebAPI.Interfaces;
using HospitalWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalWebAPI.Controllers
{
	[Authorize]
	[ApiController]
	[ApiExplorerSettings(GroupName = "equipment")]
	[Route("/[controller]")]
	public class EquipmentController : Controller
	{
		private readonly IGenericService<Equipment> _equipmentService;
		public EquipmentController(IGenericService<Equipment> equipmentService)
		{
			_equipmentService = equipmentService;
		}
		/// <summary>
		/// Список оборудования
		/// </summary>
		/// <remarks>Запрос для получения списка оборудования</remarks>
		[HttpGet(nameof(GetAllEquipment))]
		public async Task<ActionResult> GetAllEquipment()
		{
			try
			{
				var allEquipment = await _equipmentService.GetAllAsync();
				return Ok(allEquipment);
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Оборудование
		/// </summary>
		/// <param name="id">Id оборудования</param>
		/// <remarks>Запрос для получения оборудования по Id</remarks>
		[HttpGet(nameof(GetEquipmentById))]
		public async Task<ActionResult> GetEquipmentById(int id)
		{
			try
			{
				var equipment = await _equipmentService.GetEntryByIdAsync(id);
				if (equipment == null)
					return NotFound();
				return Ok(equipment);
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Создание оборудования
		/// </summary>
		/// <param name="equipment">Оборудование</param>
		/// <remarks>Запрос для создания оборудования</remarks>
		[HttpPost(nameof(CreateEquipment))]
		public async Task<ActionResult> CreateEquipment([FromBody] Equipment equipment)
		{
			try
			{
				await _equipmentService.CreateEntryAsync(equipment);
				return Ok(await _equipmentService.GetEntryByIdAsync(equipment.Id));
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Обновление оборудования
		/// </summary>
		/// <param name="id">Id оборудования</param>
		/// <param name="equipment">Оборудование</param>
		/// <remarks>Запрос для обновления оборудования</remarks>
		[HttpPut(nameof(UpdateEquipment))]
		public async Task<ActionResult> UpdateEquipment(int id, [FromBody] Equipment equipment)
		{
			try
			{
				if (id != equipment.Id)
					return BadRequest();
				await _equipmentService.UpdateEntryAsync(equipment);
				return Ok(await _equipmentService.GetEntryByIdAsync(equipment.Id));
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Удаление оборудования
		/// </summary>
		/// <param name="id">Id оборудования</param>
		/// <remarks>Запрос для удаления оборудования</remarks>
		[HttpDelete(nameof(DeleteEquipment))]
		public async Task<ActionResult> DeleteEquipment(int id)
		{
			try
			{
				await _equipmentService.DeleteEntryAsync(id);
				return Ok();
			}
			catch
			{
				return StatusCode(500);
			}
		}
	}
}
