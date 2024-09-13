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
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для получения списка оборудования</remarks>
		[HttpGet(nameof(GetAllEquipmentAsync))]
		public async Task<ActionResult> GetAllEquipmentAsync(CancellationToken cancellationToken)
		{
			var allEquipment = await _equipmentService.GetAllAsync(cancellationToken);
			return Ok(allEquipment);
		}
		/// <summary>
		/// Оборудование
		/// </summary>
		/// <param name="id">Id оборудования</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для получения оборудования по Id</remarks>
		[HttpGet(nameof(GetEquipmentByIdAsync))]
		public async Task<ActionResult> GetEquipmentByIdAsync(int id, CancellationToken cancellationToken)
		{
			var equipment = await _equipmentService.GetEntryByIdAsync(id, cancellationToken);
			return Ok(equipment);
		}
		/// <summary>
		/// Создание оборудования
		/// </summary>
		/// <param name="equipment">Оборудование</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для создания оборудования</remarks>
		[HttpPost(nameof(CreateEquipmentAsync))]
		public async Task<ActionResult> CreateEquipmentAsync([FromBody] Equipment equipment, CancellationToken cancellationToken)
		{
			var createdEquipment = await _equipmentService.CreateEntryAsync(equipment, cancellationToken);
			return Ok(createdEquipment);
		}
		/// <summary>
		/// Обновление оборудования
		/// </summary>
		/// <param name="id">Id оборудования</param>
		/// <param name="equipment">Оборудование</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для обновления оборудования</remarks>
		[HttpPut(nameof(UpdateEquipmentAsync))]
		public async Task<ActionResult> UpdateEquipmentAsync(int id, [FromBody] Equipment equipment, CancellationToken cancellationToken)
		{
			var updatedEquipment = await _equipmentService.UpdateEntryAsync(equipment, cancellationToken);
			return Ok(updatedEquipment);
		}
		/// <summary>
		/// Удаление оборудования
		/// </summary>
		/// <param name="id">Id оборудования</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для удаления оборудования</remarks>
		[HttpDelete(nameof(DeleteEquipmentAsync))]
		public async Task<ActionResult> DeleteEquipmentAsync(int id, CancellationToken cancellationToken)
		{
			await _equipmentService.DeleteEntryAsync(id, cancellationToken);
			return Ok();
		}
	}
}
