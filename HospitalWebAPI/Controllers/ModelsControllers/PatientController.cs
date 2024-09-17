using HospitalWebAPI.Interfaces;
using HospitalWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalWebAPI.Controllers.ModelsControllers
{
	[Authorize]
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
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для получения списка пациентов</remarks>
		[HttpGet(nameof(GetPatientsAsync))]
		public async Task<ActionResult> GetPatientsAsync(CancellationToken cancellationToken)
		{
			var patients = await _patientService.GetAllAsync(cancellationToken);
			return Ok(patients);
		}
		/// <summary>
		/// Excel-отчет по пациентам
		/// </summary>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <returns></returns>
		/// <remarks>Запрос для получения Excel-файла по пациентам</remarks>
		[HttpGet(nameof(GetPatientsExcelFileAsync))]
		public async Task<FileResult> GetPatientsExcelFileAsync(CancellationToken cancellationToken)
		{
			var xlFile = await _patientService.GetAllExcelFileAsync(cancellationToken);
			return File(xlFile.File.ToArray(), xlFile.ContentType, xlFile.FileName);
		}
		/// <summary>
		/// Пациент
		/// </summary>
		/// <param name="id">Id пациента</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для получения пациента по Id</remarks>
		[HttpGet(nameof(GetPatientByIdAsync))]
		public async Task<ActionResult> GetPatientByIdAsync(int id, CancellationToken cancellationToken)
		{
			var patient = await _patientService.GetEntryByIdAsync(id, cancellationToken);
			return Ok(patient);
		}
		/// <summary>
		/// Создание пациента
		/// </summary>
		/// <param name="patient">Пациент</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для создания пациента</remarks>
		[HttpPost(nameof(CreatePatientAsync))]
		public async Task<ActionResult> CreatePatientAsync([FromBody] Patient patient, CancellationToken cancellationToken)
		{
			var createdPatient = await _patientService.CreateEntryAsync(patient, cancellationToken);
			return Ok(createdPatient);
		}
		/// <summary>
		/// Обновление пациента
		/// </summary>
		/// <param name="patient">Пациент</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для обновления пациента</remarks>
		[HttpPut(nameof(UpdatePatientAsync))]
		public async Task<ActionResult> UpdatePatientAsync([FromBody] Patient patient, CancellationToken cancellationToken)
		{
			var updatedPatient = await _patientService.UpdateEntryAsync(patient, cancellationToken);
			return Ok(updatedPatient);
		}
		/// <summary>
		/// Удаление пациента
		/// </summary>
		/// <param name="id">Id пациента</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для удаления пациента</remarks>
		[HttpDelete(nameof(DeletePatientAsync))]
		public async Task<ActionResult> DeletePatientAsync(int id, CancellationToken cancellationToken)
		{
			await _patientService.DeleteEntryAsync(id, cancellationToken);
			return Ok();
		}
	}
}
