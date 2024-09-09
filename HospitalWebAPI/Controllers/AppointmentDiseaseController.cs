using HospitalWebAPI.Interfaces;
using HospitalWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalWebAPI.Controllers
{
	[Authorize]
	[ApiController]
	[ApiExplorerSettings(GroupName = "appointmentDiseases")]
	[Route("/[controller]")]
	public class AppointmentDiseaseController : Controller
    {
		private readonly IGenericService<AppointmentDisease> _appointmentDiseaseService;
		public AppointmentDiseaseController(IGenericService<AppointmentDisease> appointmentDiseaseService)
		{
			_appointmentDiseaseService = appointmentDiseaseService;
		}
		/// <summary>
		/// Список данных из AppointmentDisease
		/// </summary>
		/// <remarks>Запрос для получения списка из сущности, которая связывает между собой Appointment и Disease</remarks>
		[HttpGet(nameof(GetAppointmentDiseases))]
		public async Task<ActionResult> GetAppointmentDiseases()
		{
			try
			{
				var appointmentDiseases = await _appointmentDiseaseService.GetAllAsync();
				return Ok(appointmentDiseases);
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Запись из AppointmentDisease
		/// </summary>
		/// <param name="id">Id записи из AppointmentDisease</param>
		/// <remarks>Запрос для получения записи из сущности, которая связывает между собой Appointment и Disease</remarks>
		[HttpGet(nameof(GetAppointmentDiseaseById))]
		public async Task<ActionResult> GetAppointmentDiseaseById(int id)
		{
			try
			{
				var appointmentDisease = await _appointmentDiseaseService.GetEntryByIdAsync(id);
				if (appointmentDisease == null)
					return NotFound();
				return Ok(appointmentDisease);
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Создание записи из AppointmentDisease
		/// </summary>
		/// <param name="appointmentDisease">Запись на прием</param>
		/// <remarks>Запрос для создания записи из AppointmentDisease</remarks>
		[HttpPost(nameof(CreateAppointmentDisease))]
		public async Task<ActionResult> CreateAppointmentDisease([FromBody] AppointmentDisease appointmentDisease)
		{
			try
			{
				await _appointmentDiseaseService.CreateEntryAsync(appointmentDisease);
				return Ok(await _appointmentDiseaseService.GetEntryByIdAsync(appointmentDisease.Id));
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Обновление записи из AppointmentDisease
		/// </summary>
		/// <param name="id">Id записи из AppointmentDisease</param>
		/// <param name="appointmentDisease">Запись на прием</param>
		/// <remarks>Запрос для обновления записи из AppointmentDisease</remarks>
		[HttpPut(nameof(UpdateAppointmentDisease))]
		public async Task<ActionResult> UpdateAppointmentDisease(int id, [FromBody] AppointmentDisease appointmentDisease)
		{
			try
			{
				if (id != appointmentDisease.Id)
					return BadRequest();
				await _appointmentDiseaseService.UpdateEntryAsync(appointmentDisease);
				return Ok(await _appointmentDiseaseService.GetEntryByIdAsync(appointmentDisease.Id));
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Удаление записи из AppointmentDisease
		/// </summary>
		/// <param name="id">Id записи из AppointmentDisease</param>
		/// <remarks>Запрос для удаления записи из AppointmentDisease</remarks>
		[HttpDelete(nameof(DeleteAppointmentDisease))]
		public async Task<ActionResult> DeleteAppointmentDisease(int id)
		{
			try
			{
				await _appointmentDiseaseService.DeleteEntryAsync(id);
				return Ok();
			}
			catch
			{
				return StatusCode(500);
			}
		}
	}
}
