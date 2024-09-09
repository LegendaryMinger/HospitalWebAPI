using HospitalWebAPI.Interfaces;
using HospitalWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalWebAPI.Controllers
{
	[Authorize]
	[ApiController]
	[ApiExplorerSettings(GroupName = "patients")]
	[Route("/[controller]")]
	public class PatientController : Controller
	{
		private readonly IGenericService<Patient> _patientService;
		public PatientController(IGenericService<Patient> patientService)
		{
			_patientService = patientService;
		}
		/// <summary>
		/// Список пациентов
		/// </summary>
		/// <remarks>Запрос для получения списка пациентов</remarks>
		[HttpGet(nameof(GetPatients))]
		public async Task<ActionResult> GetPatients()
		{
			try
			{
				var patients = await _patientService.GetAllAsync();
				return Ok(patients);
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Пациент
		/// </summary>
		/// <param name="id">Id пациента</param>
		/// <remarks>Запрос для получения пациента по Id</remarks>
		[HttpGet(nameof(GetPatientById))]
		public async Task<ActionResult> GetPatientById(int id)
		{
			try
			{
				var patient = await _patientService.GetEntryByIdAsync(id);
				if (patient == null)
					return NotFound();
				return Ok(patient);
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Создание пациента
		/// </summary>
		/// <param name="patient">Пациент</param>
		/// <remarks>Запрос для создания пациента</remarks>
		[HttpPost(nameof(CreatePatient))]
		public async Task<ActionResult> CreatePatient([FromBody] Patient patient)
		{
			try
			{
				await _patientService.CreateEntryAsync(patient);
				return Ok(await _patientService.GetEntryByIdAsync(patient.Id));
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Обновление пациента
		/// </summary>
		/// <param name="id">Id пациента</param>
		/// <param name="patient">Пациент</param>
		/// <remarks>Запрос для обновления пациента</remarks>
		[HttpPut(nameof(UpdatePatient))]
		public async Task<ActionResult> UpdatePatient(int id, [FromBody] Patient patient)
		{
			try
			{
				if (id != patient.Id)
					return BadRequest();
				await _patientService.UpdateEntryAsync(patient);
				return Ok(await _patientService.GetEntryByIdAsync(patient.Id));
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Удаление пациента
		/// </summary>
		/// <param name="id">Id пациента</param>
		/// <remarks>Запрос для удаления пациента</remarks>
		[HttpDelete(nameof(DeletePatient))]
		public async Task<ActionResult> DeletePatient(int id)
		{
			try
			{
				await _patientService.DeleteEntryAsync(id);
				return Ok();
			}
			catch
			{
				return StatusCode(500);
			}
		}
	}
}
