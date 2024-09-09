using HospitalWebAPI.Interfaces;
using HospitalWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalWebAPI.Controllers
{
	[Authorize]
	[ApiController]
	[ApiExplorerSettings(GroupName = "payments")]
	[Route("/[controller]")]
	public class PaymentController : Controller
	{
		private readonly IGenericService<Payment> _paymentService;
		public PaymentController(IGenericService<Payment> paymentService)
		{
			_paymentService = paymentService;
		}
		/// <summary>
		/// Список платежей
		/// </summary>
		/// <remarks>Запрос для получения списка платежей</remarks>
		[HttpGet(nameof(GetPayments))]
		public async Task<ActionResult> GetPayments()
		{
			try
			{
				var payments = await _paymentService.GetAllAsync();
				return Ok(payments);
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Платеж
		/// </summary>
		/// <param name="id">Id платежа</param>
		/// <remarks>Запрос для получения платежа по Id</remarks>
		[HttpGet(nameof(GetPaymentById))]
		public async Task<ActionResult> GetPaymentById(int id)
		{
			try
			{
				var payment = await _paymentService.GetEntryByIdAsync(id);
				if (payment == null)
					return NotFound();
				return Ok(payment);
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Создание платежа
		/// </summary>
		/// <param name="payment">Платеж</param>
		/// <remarks>Запрос для создания платежа</remarks>
		[HttpPost(nameof(CreatePayment))]
		public async Task<ActionResult> CreatePayment([FromBody] Payment payment)
		{
			try
			{
				await _paymentService.CreateEntryAsync(payment);
				return Ok(await _paymentService.GetEntryByIdAsync(payment.Id));
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Обновление платежа
		/// </summary>
		/// <param name="id">Id платежа</param>
		/// <param name="payment">Платеж</param>
		/// <remarks>Запрос для обновления платежа</remarks>
		[HttpPut(nameof(UpdatePayment))]
		public async Task<ActionResult> UpdatePayment(int id, [FromBody] Payment payment)
		{
			try
			{
				if (id != payment.Id)
					return BadRequest();
				await _paymentService.UpdateEntryAsync(payment);
				return Ok(await _paymentService.GetEntryByIdAsync(payment.Id));
			}
			catch
			{
				return StatusCode(500);
			}
		}
		/// <summary>
		/// Удаление платежа
		/// </summary>
		/// <param name="id">Id платежа</param>
		/// <remarks>Запрос для удаления платежа</remarks>
		[HttpDelete(nameof(DeletePayment))]
		public async Task<ActionResult> DeletePayment(int id)
		{
			try
			{
				await _paymentService.DeleteEntryAsync(id);
				return Ok();
			}
			catch
			{
				return StatusCode(500);
			}
		}
	}
}
