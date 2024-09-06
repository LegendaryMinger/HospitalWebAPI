using HospitalWebAPI.Contexts;
using HospitalWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HospitalWebAPI.Controllers
{
	[Route("/DataRetrievalController")]
	[ApiExplorerSettings(GroupName = "v1")]
	public class DataRetrievalController : Controller
	{
		/// <summary>
		/// Список записей на прием
		/// </summary>
		/// <remarks>Запрос для получения списка записей на прием</remarks>
		[Route("Appointment")]
		[HttpGet]
		[ProducesResponseType(typeof(List<Appointment>), 200)]
		[ProducesResponseType(500)]
		public ActionResult AppointmentList()
		{
			try
			{
				using (var context = new HospitalContext())
				{
					IEnumerable<Appointment> AppointmentList = context.Appointment.ToList();
					return Json(AppointmentList);
				}
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
		[Route("AppointmentDisease")]
		[HttpGet]
		[ProducesResponseType(typeof(List<AppointmentDisease>), 200)]
		[ProducesResponseType(500)]
		public ActionResult AppointmentDiseaseList()
		{
			try
			{
				using (var context = new HospitalContext())
				{
					IEnumerable<AppointmentDisease> AppointmentDiseaseList = context.AppointmentDisease.ToList();
					return Json(AppointmentDiseaseList);
				}
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
		[Route("Comment")]
		[HttpGet]
		[ProducesResponseType(typeof(List<Comment>), 200)]
		[ProducesResponseType(500)]
		public ActionResult CommentList()
		{
			try
			{
				using (var context = new HospitalContext())
				{
					IEnumerable<Comment> CommentList = context.Comment.ToList();
					return Json(CommentList);
				}
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
		[Route("Department")]
		[HttpGet]
		[ProducesResponseType(typeof(List<Department>), 200)]
		[ProducesResponseType(500)]
		public ActionResult DepartmentList()
		{
			try
			{
				using (var context = new HospitalContext())
				{
					IEnumerable<Department> DepartmentList = context.Department.ToList();
					return Json(DepartmentList);
				}
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
		[Route("Disease")]
		[HttpGet]
		[ProducesResponseType(typeof(List<Disease>), 200)]
		[ProducesResponseType(500)]
		public ActionResult DiseaseList()
		{
			try
			{
				using (var context = new HospitalContext())
				{
					IEnumerable<Disease> DiseaseList = context.Disease.ToList();
					return Json(DiseaseList);
				}
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
		[Route("Employee")]
		[HttpGet]
		[ProducesResponseType(typeof(List<Employee>), 200)]
		[ProducesResponseType(500)]
		public ActionResult EmployeeList()
		{
			try
			{
				using (var context = new HospitalContext())
				{
					IEnumerable<Employee> EmployeeList = context.Employee.ToList();
					return Json(EmployeeList);
				}
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
		[Route("Equipment")]
		[HttpGet]
		[ProducesResponseType(typeof(List<Equipment>), 200)]
		[ProducesResponseType(500)]
		public ActionResult EquipmentList()
		{
			try
			{
				using (var context = new HospitalContext())
				{
					IEnumerable<Equipment> EquipmentList = context.Equipment.ToList();
					return Json(EquipmentList);
				}
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
		[Route("Gender")]
		[HttpGet]
		[ProducesResponseType(typeof(List<Gender>), 200)]
		[ProducesResponseType(500)]
		public ActionResult GenderList()
		{
			try
			{
				using (var context = new HospitalContext())
				{
					IEnumerable<Gender> GenderList = context.Gender.ToList();
					return Json(GenderList);
				}
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
		[Route("History")]
		[HttpGet]
		[ProducesResponseType(typeof(List<History>), 200)]
		[ProducesResponseType(500)]
		public ActionResult HistoryList()
		{
			try
			{
				using (var context = new HospitalContext())
				{
					IEnumerable<History> HistoryList = context.History.ToList();
					return Json(HistoryList);
				}
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
		[Route("Instruction")]
		[HttpGet]
		[ProducesResponseType(typeof(List<Instruction>), 200)]
		[ProducesResponseType(500)]
		public ActionResult InstructionList()
		{
			try
			{
				using (var context = new HospitalContext())
				{
					IEnumerable<Instruction> InstructionList = context.Instruction.ToList();
					return Json(InstructionList);
				}
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
		[Route("Patient")]
		[HttpGet]
		[ProducesResponseType(typeof(List<Patient>), 200)]
		[ProducesResponseType(500)]
		public ActionResult PatientList()
		{
			try
			{
				using (var context = new HospitalContext())
				{
					IEnumerable<Patient> PatientList = context.Patient.ToList();
					return Json(PatientList);
				}
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
		public ActionResult PaymentList()
		{
			try
			{
				using (var context = new HospitalContext())
				{
					IEnumerable<Payment> PaymentList = context.Payment.ToList();
					return Json(PaymentList);
				}
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
		[Route("Service")]
		[HttpGet]
		[ProducesResponseType(typeof(List<Service>), 200)]
		[ProducesResponseType(500)]
		public ActionResult ServiceList()
		{
			try
			{
				using (var context = new HospitalContext())
				{
					IEnumerable<Service> ServiceList = context.Service.ToList();
					return Json(ServiceList);
				}
			}
			catch
			{
				return StatusCode(500);
			}
		}
	}
}
