using HospitalWebAPI.Interfaces;
using HospitalWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalWebAPI.Controllers
{
	[Authorize]
	[ApiController]
	[ApiExplorerSettings(GroupName = "services")]
	[Route("/[controller]")]
	public class ServiceController : Controller
	{
		private readonly IGenericService<Service> _serviceService;
		public ServiceController(IGenericService<Service> serviceService)
		{
			_serviceService = serviceService;
		}
		/// <summary>
		/// Список услуг
		/// </summary>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для получения списка услуг</remarks>
		[HttpGet(nameof(GetServicesAsync))]
		public async Task<ActionResult> GetServicesAsync(CancellationToken cancellationToken)
		{
			var services = await _serviceService.GetAllAsync(cancellationToken);
			return Ok(services);
		}
		/// <summary>
		/// Услуга
		/// </summary>
		/// <param name="id">Id услуги</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для получения услуги по Id</remarks>
		[HttpGet(nameof(GetServiceByIdAsync))]
		public async Task<ActionResult> GetServiceByIdAsync(int id, CancellationToken cancellationToken)
		{
			var service = await _serviceService.GetEntryByIdAsync(id, cancellationToken);
			return Ok(service);
		}
		/// <summary>
		/// Создание услуги
		/// </summary>
		/// <param name="service">Услуга</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для создания услуги</remarks>
		[HttpPost(nameof(CreateServiceAsync))]
		public async Task<ActionResult> CreateServiceAsync([FromBody] Service service, CancellationToken cancellationToken)
		{
			var createdService = await _serviceService.CreateEntryAsync(service, cancellationToken);
			return Ok(createdService);
		}
		/// <summary>
		/// Обновление услуги
		/// </summary>
		/// <param name="id">Id услуги</param>
		/// <param name="service">Услуга</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для обновления услуги</remarks>
		[HttpPut(nameof(UpdateServiceAsync))]
		public async Task<ActionResult> UpdateServiceAsync(int id, [FromBody] Service service, CancellationToken cancellationToken)
		{
			var updatedService = await _serviceService.UpdateEntryAsync(service, cancellationToken);
			return Ok(updatedService);
		}
		/// <summary>
		/// Удаление услуги
		/// </summary>
		/// <param name="id">Id услуги</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для удаления услуги</remarks>
		[HttpDelete(nameof(DeleteServiceAsync))]
		public async Task<ActionResult> DeleteServiceAsync(int id, CancellationToken cancellationToken)
		{
			await _serviceService.DeleteEntryAsync(id, cancellationToken);
			return Ok();
		}
	}
}
