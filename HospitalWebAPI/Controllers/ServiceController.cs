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
		/// <remarks>Запрос для получения списка услуг</remarks>
		[HttpGet(nameof(GetServices))]
		public async Task<ActionResult> GetServices()
		{
			try
			{
				var services = await _serviceService.GetAllAsync();
				return Ok(services);
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Услуга
		/// </summary>
		/// <param name="id">Id услуги</param>
		/// <remarks>Запрос для получения услуги по Id</remarks>
		[HttpGet(nameof(GetServiceById))]
		public async Task<ActionResult> GetServiceById(int id)
		{
			try
			{
				var service = await _serviceService.GetEntryByIdAsync(id);
				if (service == null)
					return NotFound();
				return Ok(service);
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Создание услуги
		/// </summary>
		/// <param name="service">Услуга</param>
		/// <remarks>Запрос для создания услуги</remarks>
		[HttpPost(nameof(CreateService))]
		public async Task<ActionResult> CreateService([FromBody] Service service)
		{
			try
			{
				await _serviceService.CreateEntryAsync(service);
				return Ok(await _serviceService.GetEntryByIdAsync(service.Id));
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Обновление услуги
		/// </summary>
		/// <param name="id">Id услуги</param>
		/// <param name="service">Услуга</param>
		/// <remarks>Запрос для обновления услуги</remarks>
		[HttpPut(nameof(UpdateService))]
		public async Task<ActionResult> UpdateService(int id, [FromBody] Service service)
		{
			try
			{
				if (id != service.Id)
					return BadRequest();
				await _serviceService.UpdateEntryAsync(service);
				return Ok(await _serviceService.GetEntryByIdAsync(service.Id));
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Удаление услуги
		/// </summary>
		/// <param name="id">Id услуги</param>
		/// <remarks>Запрос для удаления услуги</remarks>
		[HttpDelete(nameof(DeleteService))]
		public async Task<ActionResult> DeleteService(int id)
		{
			try
			{
				await _serviceService.DeleteEntryAsync(id);
				return Ok();
			}
			catch
			{
				return StatusCode(500);
			}
		}
	}
}
