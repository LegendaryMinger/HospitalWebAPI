using HospitalWebAPI.Interfaces;
using HospitalWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalWebAPI.Controllers
{
	[Authorize]
	[ApiController]
	[ApiExplorerSettings(GroupName = "employees")]
	[Route("/[controller]")]
	public class EmployeeController : Controller
	{
		private readonly IGenericService<Employee> _employeeService;
		public EmployeeController(IGenericService<Employee> employeeService)
		{
			_employeeService = employeeService;
		}
		/// <summary>
		/// Список сотрудников
		/// </summary>
		/// <remarks>Запрос для получения списка сотрудников</remarks>
		[HttpGet(nameof(GetEmployees))]
		public async Task<ActionResult> GetEmployees()
		{
			try
			{
				var employees = await _employeeService.GetAllAsync();
				return Ok(employees);
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Сотрудник
		/// </summary>
		/// <param name="id">Id болезни</param>
		/// <remarks>Запрос для получения сотрудника по Id</remarks>
		[HttpGet(nameof(GetEmployeeById))]
		public async Task<ActionResult> GetEmployeeById(int id)
		{
			try
			{
				var employee = await _employeeService.GetEntryByIdAsync(id);
				if (employee == null)
					return NotFound();
				return Ok(employee);
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Создание сотрудника
		/// </summary>
		/// <param name="employee">Сотрудник</param>
		/// <remarks>Запрос для создания сотрудника</remarks>
		[HttpPost(nameof(CreateEmployee))]
		public async Task<ActionResult> CreateEmployee([FromBody] Employee employee)
		{
			try
			{
				await _employeeService.CreateEntryAsync(employee);
				return Ok(await _employeeService.GetEntryByIdAsync(employee.Id));
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Обновление сотрудника
		/// </summary>
		/// <param name="id">Id сотрудника</param>
		/// <param name="employee">Сотрудник</param>
		/// <remarks>Запрос для обновления сотрудника</remarks>
		[HttpPut(nameof(UpdateEmployee))]
		public async Task<ActionResult> UpdateEmployee(int id, [FromBody] Employee employee)
		{
			try
			{
				if (id != employee.Id)
					return BadRequest();
				await _employeeService.UpdateEntryAsync(employee);
				return Ok(await _employeeService.GetEntryByIdAsync(employee.Id));
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Удаление сотрудника
		/// </summary>
		/// <param name="id">Id сотрудника</param>
		/// <remarks>Запрос для удаления сотрудника</remarks>
		[HttpDelete(nameof(DeleteEmployee))]
		public async Task<ActionResult> DeleteEmployee(int id)
		{
			try
			{
				await _employeeService.DeleteEntryAsync(id);
				return Ok();
			}
			catch
			{
				return StatusCode(500);
			}
		}
	}
}
