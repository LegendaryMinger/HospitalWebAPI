using HospitalWebAPI.Contexts;
using HospitalWebAPI.Interfaces;
using HospitalWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HospitalWebAPI.Controllers
{
	[Authorize]
	[ApiController]
	[ApiExplorerSettings(GroupName = "appointments")]
	[Route("/[controller]")]
	public class AppointmentController : Controller
	{
		private readonly IGenericService<Appointment> _appointmentService;
		public AppointmentController(IGenericService<Appointment> appointmentService)
		{
			_appointmentService = appointmentService;
		}
		/// <summary>
		/// Список записей на прием
		/// </summary>
		/// <remarks>Запрос для получения списка записей на прием</remarks>
		[HttpGet(nameof(GetAppointments))]
		public async Task<ActionResult> GetAppointments()
		{
			try
			{
				var appointments = await _appointmentService.GetAllAsync();
				return Ok(appointments);
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Запись на прием
		/// </summary>
		/// <param name="id">Id записи на прием</param>
		/// <remarks>Запрос для получения записи на прием по Id</remarks>
		[HttpGet(nameof(GetAppointmentById))]
		public async Task<ActionResult> GetAppointmentById(int id)
		{
			try
			{
				var appointment = await _appointmentService.GetEntryByIdAsync(id);
				if (appointment == null)
					return NotFound();
				return Ok(appointment);
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Создание записи на прием
		/// </summary>
		/// <param name="appointment">Запись на прием</param>
		/// <remarks>Запрос для создания записи на прием</remarks>
		[HttpPost(nameof(CreateAppointment))]
		public async Task<ActionResult> CreateAppointment([FromBody] Appointment appointment)
		{
			try
			{
				await _appointmentService.CreateEntryAsync(appointment);
				return Ok(await _appointmentService.GetEntryByIdAsync(appointment.Id));
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Обновление записи на прием
		/// </summary>
		/// <param name="id">Id записи на прием</param>
		/// <param name="appointment">Запись на прием</param>
		/// <remarks>Запрос для обновления записи на прием</remarks>
		[HttpPut(nameof(UpdateAppointment))]
		public async Task<ActionResult> UpdateAppointment(int id, [FromBody] Appointment appointment)
		{
			try
			{
				if (id != appointment.Id)
					return BadRequest();
				await _appointmentService.UpdateEntryAsync(appointment);
				return Ok(await _appointmentService.GetEntryByIdAsync(appointment.Id));
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Удаление записи на прием
		/// </summary>
		/// <param name="id">Id записи на прием</param>
		/// <remarks>Запрос для удаления записи на прием</remarks>
		[HttpDelete(nameof(DeleteAppointment))]
		public async Task<ActionResult> DeleteAppointment(int id)
		{
			try
			{
				await _appointmentService.DeleteEntryAsync(id);
				return Ok();
			}
			catch
			{
				return StatusCode(500);
			}
		}
	}
}
