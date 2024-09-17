using HospitalWebAPI.Interfaces;
using HospitalWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalWebAPI.Controllers.ModelsControllers
{
	[Authorize]
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
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для получения списка из сущности, которая связывает между собой Appointment и Disease</remarks>
		[HttpGet(nameof(GetAppointmentDiseasesAsync))]
		public async Task<ActionResult> GetAppointmentDiseasesAsync(CancellationToken cancellationToken)
		{
			var appointmentDiseases = await _appointmentDiseaseService.GetAllAsync(cancellationToken);
			return Ok(appointmentDiseases);
		}
		/// <summary>
		/// Excel-отчет по данным из AppointmentDisease
		/// </summary>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <returns></returns>
		/// <remarks>Запрос для получения Excel-файла по данным из AppointmentDisease</remarks>
		[HttpGet(nameof(GetAppointmentDiseasesExcelFileAsync))]
		public async Task<FileResult> GetAppointmentDiseasesExcelFileAsync(CancellationToken cancellationToken)
		{
			var xlFile = await _appointmentDiseaseService.GetAllExcelFileAsync(cancellationToken);
			return File(xlFile.File.ToArray(), xlFile.ContentType, xlFile.FileName);
		}
		/// <summary>
		/// Запись из AppointmentDisease
		/// </summary>
		/// <param name="id">Id записи из AppointmentDisease</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для получения записи из сущности, которая связывает между собой Appointment и Disease</remarks>
		[HttpGet(nameof(GetAppointmentDiseaseByIdAsync))]
		public async Task<ActionResult> GetAppointmentDiseaseByIdAsync(int id, CancellationToken cancellationToken)
		{
			var appointmentDisease = await _appointmentDiseaseService.GetEntryByIdAsync(id, cancellationToken);
			return Ok(appointmentDisease);
		}
		/// <summary>
		/// Создание записи из AppointmentDisease
		/// </summary>
		/// <param name="appointmentDisease">Запись на прием</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для создания записи из AppointmentDisease</remarks>
		[HttpPost(nameof(CreateAppointmentDiseaseAsync))]
		public async Task<ActionResult> CreateAppointmentDiseaseAsync([FromBody] AppointmentDisease appointmentDisease, CancellationToken cancellationToken)
		{
			var createdAppointmentDisease = await _appointmentDiseaseService.CreateEntryAsync(appointmentDisease, cancellationToken);
			return Ok(createdAppointmentDisease);
		}
		/// <summary>
		/// Обновление записи из AppointmentDisease
		/// </summary>
		/// <param name="appointmentDisease">Запись на прием</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для обновления записи из AppointmentDisease</remarks>
		[HttpPut(nameof(UpdateAppointmentDiseaseAsync))]
		public async Task<ActionResult> UpdateAppointmentDiseaseAsync([FromBody] AppointmentDisease appointmentDisease, CancellationToken cancellationToken)
		{
			var updatedAppointmentDisease = await _appointmentDiseaseService.UpdateEntryAsync(appointmentDisease, cancellationToken);
			return Ok(updatedAppointmentDisease);
		}
		/// <summary>
		/// Удаление записи из AppointmentDisease
		/// </summary>
		/// <param name="id">Id записи из AppointmentDisease</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для удаления записи из AppointmentDisease</remarks>
		[HttpDelete(nameof(DeleteAppointmentDiseaseAsync))]
		public async Task<ActionResult> DeleteAppointmentDiseaseAsync(int id, CancellationToken cancellationToken)
		{
			await _appointmentDiseaseService.DeleteEntryAsync(id, cancellationToken);
			return Ok();
		}
	}
}
