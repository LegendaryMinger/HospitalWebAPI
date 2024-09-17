using HospitalWebAPI.Interfaces;
using HospitalWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalWebAPI.Controllers.ModelsControllers
{
	[Authorize]
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
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для получения списка отделений</remarks>
		[HttpGet(nameof(GetDepartmentsAsync))]
		public async Task<ActionResult> GetDepartmentsAsync(CancellationToken cancellationToken)
		{
			var departments = await _departmentService.GetAllAsync(cancellationToken);
			return Ok(departments);
		}
		/// <summary>
		/// Excel-отчет по отделениям
		/// </summary>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <returns></returns>
		/// <remarks>Запрос для получения Excel-файла по отделениям</remarks>
		[HttpGet(nameof(GetDepartmentsExcelFileAsync))]
		public async Task<FileResult> GetDepartmentsExcelFileAsync(CancellationToken cancellationToken)
		{
			var xlFile = await _departmentService.GetAllExcelFileAsync(cancellationToken);
			return File(xlFile.File.ToArray(), xlFile.ContentType, xlFile.FileName);
		}
		/// <summary>
		/// Отделение
		/// </summary>
		/// <param name="id">Id отделения</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для получения отделения по Id</remarks>
		[HttpGet(nameof(GetDepartmentByIdAsync))]
		public async Task<ActionResult> GetDepartmentByIdAsync(int id, CancellationToken cancellationToken)
		{
			var department = await _departmentService.GetEntryByIdAsync(id, cancellationToken);
			return Ok(department);
		}
		/// <summary>
		/// Создание отделения
		/// </summary>
		/// <param name="department">Запись на прием</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для создания отделения</remarks>
		[HttpPost(nameof(CreateDepartmentAsync))]
		public async Task<ActionResult> CreateDepartmentAsync([FromBody] Department department, CancellationToken cancellationToken)
		{
			var createdDepartment = await _departmentService.CreateEntryAsync(department, cancellationToken);
			return Ok(createdDepartment);
		}
		/// <summary>
		/// Обновление отделения
		/// </summary>
		/// <param name="department">Запись на прием</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для обновления отделения</remarks>
		[HttpPut(nameof(UpdateDepartmentAsync))]
		public async Task<ActionResult> UpdateDepartmentAsync([FromBody] Department department, CancellationToken cancellationToken)
		{
			var updatedDepartment = await _departmentService.UpdateEntryAsync(department, cancellationToken);
			return Ok(updatedDepartment);
		}
		/// <summary>
		/// Удаление отделения
		/// </summary>
		/// <param name="id">Id отделения</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для удаления отделения</remarks>
		[HttpDelete(nameof(DeleteDepartmentAsync))]
		public async Task<ActionResult> DeleteDepartmentAsync(int id, CancellationToken cancellationToken)
		{
			await _departmentService.DeleteEntryAsync(id, cancellationToken);
			return Ok();
		}
	}
}
