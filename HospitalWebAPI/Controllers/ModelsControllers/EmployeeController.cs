using HospitalWebAPI.Interfaces;
using HospitalWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalWebAPI.Controllers.ModelsControllers
{
	[Authorize]
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
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для получения списка сотрудников</remarks>
		[HttpGet(nameof(GetEmployeesAsync))]
		public async Task<ActionResult> GetEmployeesAsync(CancellationToken cancellationToken)
		{
			var employees = await _employeeService.GetAllAsync(cancellationToken);
			return Ok(employees);
		}
		/// <summary>
		/// Excel-отчет по сотрудникам
		/// </summary>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <returns></returns>
		/// <remarks>Запрос для получения Excel-файла по сотрудникам</remarks>
		[HttpGet(nameof(GetEmployeesExcelFileAsync))]
		public async Task<FileResult> GetEmployeesExcelFileAsync(CancellationToken cancellationToken)
		{
			var xlFile = await _employeeService.GetAllExcelFileAsync(cancellationToken);
			return File(xlFile.File.ToArray(), xlFile.ContentType, xlFile.FileName);
		}
		/// <summary>
		/// Сотрудник
		/// </summary>
		/// <param name="id">Id болезни</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для получения сотрудника по Id</remarks>
		[HttpGet(nameof(GetEmployeeByIdAsync))]
		public async Task<ActionResult> GetEmployeeByIdAsync(int id, CancellationToken cancellationToken)
		{
			var employee = await _employeeService.GetEntryByIdAsync(id, cancellationToken);
			return Ok(employee);
		}
		/// <summary>
		/// Создание сотрудника
		/// </summary>
		/// <param name="employee">Сотрудник</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для создания сотрудника</remarks>
		[HttpPost(nameof(CreateEmployeeAsync))]
		public async Task<ActionResult> CreateEmployeeAsync([FromBody] Employee employee, CancellationToken cancellationToken)
		{
			var createdEmployee = await _employeeService.CreateEntryAsync(employee, cancellationToken);
			return Ok(createdEmployee);
		}
		/// <summary>
		/// Обновление сотрудника
		/// </summary>
		/// <param name="employee">Сотрудник</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для обновления сотрудника</remarks>
		[HttpPut(nameof(UpdateEmployeeAsync))]
		public async Task<ActionResult> UpdateEmployeeAsync([FromBody] Employee employee, CancellationToken cancellationToken)
		{
			var updatedEmployee = await _employeeService.UpdateEntryAsync(employee, cancellationToken);
			return Ok(updatedEmployee);
		}
		/// <summary>
		/// Удаление сотрудника
		/// </summary>
		/// <param name="id">Id сотрудника</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для удаления сотрудника</remarks>
		[HttpDelete(nameof(DeleteEmployeeAsync))]
		public async Task<ActionResult> DeleteEmployeeAsync(int id, CancellationToken cancellationToken)
		{
			await _employeeService.DeleteEntryAsync(id, cancellationToken);
			return Ok();
		}
	}
}
