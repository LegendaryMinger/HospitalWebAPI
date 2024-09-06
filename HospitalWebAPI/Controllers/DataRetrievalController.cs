using HospitalWebAPI.Contexts;
using HospitalWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HospitalWebAPI.Controllers
{
	[Authorize]
	[ApiController]
	[Route("/DataRetrievalController")]
	//[ApiExplorerSettings(GroupName = "v1")]
	public class DataRetrievalController : Controller
	{
		private readonly HospitalContext _context;
		public DataRetrievalController(HospitalContext context)
		{
			_context = context;
		}
		/// <summary>
		/// Список записей на прием
		/// </summary>
		/// <remarks>Запрос для получения списка записей на прием</remarks>
		[HttpGet("Appointment")]
		[ProducesResponseType(typeof(List<Appointment>), 200)]
		[ProducesResponseType(500)]
		public async Task<ActionResult> AppointmentList()
		{
			try
			{
				var appointmentList = await _context.Appointment.ToListAsync();
				return Json(appointmentList);
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Список данных из AppointmentDisease
		/// </summary>
		/// <remarks>Запрос для получения списка из сущности, которая связывает между собой Appointment и Disease</remarks>
		[HttpGet("AppointmentDisease")]
		[ProducesResponseType(typeof(List<AppointmentDisease>), 200)]
		[ProducesResponseType(500)]
		public async Task<ActionResult> AppointmentDiseaseList()
		{
			try
			{
				var appointmentDiseaseList = await _context.AppointmentDisease.ToListAsync();
				return Json(appointmentDiseaseList);
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Список комментариев
		/// </summary>
		/// <remarks>Запрос для получения списка комментариев</remarks>
		[HttpGet("Comment")]
		[ProducesResponseType(typeof(List<Comment>), 200)]
		[ProducesResponseType(500)]
		public async Task<ActionResult> CommentList()
		{
			try
			{
				var commentList = await _context.Comment.ToListAsync();
				return Json(commentList);
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Список отделений
		/// </summary>
		/// <remarks>Запрос для получения списка отделений</remarks>
		[HttpGet("Department")]
		[ProducesResponseType(typeof(List<Department>), 200)]
		[ProducesResponseType(500)]
		public async Task<ActionResult> DepartmentList()
		{
			try
			{
				var departmentList = await _context.Department.ToListAsync();
				return Json(departmentList);
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Список болезней
		/// </summary>
		/// <remarks>Запрос для получения списка болезней</remarks>
		[HttpGet("Disease")]
		[ProducesResponseType(typeof(List<Disease>), 200)]
		[ProducesResponseType(500)]
		public async Task<ActionResult> DiseaseList()
		{
			try
			{
				var diseaseList = await _context.Disease.ToListAsync();
				return Json(diseaseList);
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Список сотрудников
		/// </summary>
		/// <remarks>Запрос для получения списка сотрудников</remarks>
		[HttpGet("Employee")]
		[ProducesResponseType(typeof(List<Employee>), 200)]
		[ProducesResponseType(500)]
		public async Task<ActionResult> EmployeeList()
		{
			try
			{
				var employeeList = await _context.Employee.ToListAsync();
				return Json(employeeList);
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Список оборудования
		/// </summary>
		/// <remarks>Запрос для получения списка оборудования</remarks>
		[HttpGet("Equipment")]
		[ProducesResponseType(typeof(List<Equipment>), 200)]
		[ProducesResponseType(500)]
		public async Task<ActionResult> EquipmentList()
		{
			try
			{
				var equipmentList = await _context.Equipment.ToListAsync();
				return Json(equipmentList);
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Список полов
		/// </summary>
		/// <remarks>Запрос для получения списка полов</remarks>
		[HttpGet("Gender")]
		[ProducesResponseType(typeof(List<Gender>), 200)]
		[ProducesResponseType(500)]
		public async Task<ActionResult> GenderList()
		{
			try
			{
				var genderList = await _context.Gender.ToListAsync();
				return Json(genderList);
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Список историй болезни
		/// </summary>
		/// <remarks>Запрос для получения списка историй болезни</remarks>
		[HttpGet("History")]
		[ProducesResponseType(typeof(List<History>), 200)]
		[ProducesResponseType(500)]
		public async Task<ActionResult> HistoryList()
		{
			try
			{
				var historyList = await _context.History.ToListAsync();
				return Json(historyList);
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Список медицинских инструкций
		/// </summary>
		/// <remarks>Запрос для получения списка медицинских инструкций</remarks>
		[HttpGet("Instruction")]
		[ProducesResponseType(typeof(List<Instruction>), 200)]
		[ProducesResponseType(500)]
		public async Task<ActionResult> InstructionList()
		{
			try
			{
				var instructionList = await _context.Instruction.ToListAsync();
				return Json(instructionList);
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Список пациентов
		/// </summary>
		/// <remarks>Запрос для получения списка пациентов</remarks>
		[HttpGet("Patient")]
		[ProducesResponseType(typeof(List<Patient>), 200)]
		[ProducesResponseType(500)]
		public async Task<ActionResult> PatientList()
		{
			try
			{
				var patientList = await _context.Patient.ToListAsync();
				return Json(patientList);
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Список платежей
		/// </summary>
		/// <remarks>Запрос для получения списка платежей</remarks>
		[Route("Payment")]
		[HttpGet]
		[ProducesResponseType(typeof(List<Payment>), 200)]
		[ProducesResponseType(500)]
		public async Task<ActionResult> PaymentList()
		{
			try
			{
				var paymentList = await _context.Payment.ToListAsync();
				return Json(paymentList);
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Список услуг
		/// </summary>
		/// <remarks>Запрос для получения списка услуг</remarks>
		[HttpGet("Service")]
		[ProducesResponseType(typeof(List<Service>), 200)]
		[ProducesResponseType(500)]
		public async Task<ActionResult> ServiceList()
		{
			try
			{
				var serviceList = await _context.Service.ToListAsync();
				return Json(serviceList);
			}
			catch
			{
				return StatusCode(500);
			}
		}
	}
}
