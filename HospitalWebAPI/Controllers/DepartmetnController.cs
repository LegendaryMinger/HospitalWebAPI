using HospitalWebAPI.Interfaces;
using HospitalWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalWebAPI.Controllers
{
	[Authorize]
	[ApiController]
	[ApiExplorerSettings(GroupName = "departments")]
	[Route("/[controller]")]
	public class DepartmentController : Controller
	{
		private readonly IGenericService<Department> _departmentService;
		public DepartmentController(IGenericService<Department> departmentService)
		{
			_departmentService = departmentService;
		}
		/// <summary>
		/// Список отделений
		/// </summary>
		/// <remarks>Запрос для получения списка отделений</remarks>
		[HttpGet(nameof(GetDepartments))]
		public async Task<ActionResult> GetDepartments()
		{
			try
			{
				var departments = await _departmentService.GetAllAsync();
				return Ok(departments);
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Отделение
		/// </summary>
		/// <param name="id">Id отделения</param>
		/// <remarks>Запрос для получения отделения по Id</remarks>
		[HttpGet(nameof(GetDepartmentById))]
		public async Task<ActionResult> GetDepartmentById(int id)
		{
			try
			{
				var department = await _departmentService.GetEntryByIdAsync(id);
				if (department == null)
					return NotFound();
				return Ok(department);
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Создание отделения
		/// </summary>
		/// <param name="department">Запись на прием</param>
		/// <remarks>Запрос для создания отделения</remarks>
		[HttpPost(nameof(CreateDepartment))]
		public async Task<ActionResult> CreateDepartment([FromBody] Department department)
		{
			try
			{
				await _departmentService.CreateEntryAsync(department);
				return Ok(await _departmentService.GetEntryByIdAsync(department.Id));
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Обновление отделения
		/// </summary>
		/// <param name="id">Id отделения</param>
		/// <param name="department">Запись на прием</param>
		/// <remarks>Запрос для обновления отделения</remarks>
		[HttpPut(nameof(UpdateDepartment))]
		public async Task<ActionResult> UpdateDepartment(int id, [FromBody] Department department)
		{
			try
			{
				if (id != department.Id)
					return BadRequest();
				await _departmentService.UpdateEntryAsync(department);
				return Ok(await _departmentService.GetEntryByIdAsync(department.Id));
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Удаление отделения
		/// </summary>
		/// <param name="id">Id отделения</param>
		/// <remarks>Запрос для удаления отделения</remarks>
		[HttpDelete(nameof(DeleteDepartment))]
		public async Task<ActionResult> DeleteDepartment(int id)
		{
			try
			{
				await _departmentService.DeleteEntryAsync(id);
				return Ok();
			}
			catch
			{
				return StatusCode(500);
			}
		}
	}
}
