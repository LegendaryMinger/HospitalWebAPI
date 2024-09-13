﻿using HospitalWebAPI.Contexts;
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
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для получения списка записей на прием</remarks>
		[HttpGet(nameof(GetAppointmentsAsync))]
		public async Task<ActionResult> GetAppointmentsAsync(CancellationToken cancellationToken)
		{
			var appointments = await _appointmentService.GetAllAsync(cancellationToken);
			return Ok(appointments);
		}
		/// <summary>
		/// Запись на прием
		/// </summary>
		/// <param name="id">Id записи на прием</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для получения записи на прием по Id</remarks>
		[HttpGet(nameof(GetAppointmentByIdAsync))]
		public async Task<ActionResult> GetAppointmentByIdAsync(int id, CancellationToken cancellationToken)
		{
			var appointment = await _appointmentService.GetEntryByIdAsync(id, cancellationToken);
			return Ok(appointment);
		}
		/// <summary>
		/// Создание записи на прием
		/// </summary>
		/// <param name="appointment">Запись на прием</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для создания записи на прием</remarks>
		[HttpPost(nameof(CreateAppointmentAsync))]
		public async Task<ActionResult> CreateAppointmentAsync([FromBody] Appointment appointment, CancellationToken cancellationToken)
		{
			var createdAppointment = await _appointmentService.CreateEntryAsync(appointment, cancellationToken);
			return Ok(createdAppointment);
		}
		/// <summary>
		/// Обновление записи на прием
		/// </summary>
		/// <param name="id">Id записи на прием</param>
		/// <param name="appointment">Запись на прием</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для обновления записи на прием</remarks>
		[HttpPut(nameof(UpdateAppointmentAsync))]
		public async Task<ActionResult> UpdateAppointmentAsync(int id, [FromBody] Appointment appointment, CancellationToken cancellationToken)
		{
			var updatedAppointment = await _appointmentService.UpdateEntryAsync(appointment, cancellationToken);
			return Ok(updatedAppointment);
		}
		/// <summary>
		/// Удаление записи на прием
		/// </summary>
		/// <param name="id">Id записи на прием</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для удаления записи на прием</remarks>
		[HttpDelete(nameof(DeleteAppointmentAsync))]
		public async Task<ActionResult> DeleteAppointmentAsync(int id, CancellationToken cancellationToken)
		{
			await _appointmentService.DeleteEntryAsync(id, cancellationToken);
			return Ok();
		}
	}
}
