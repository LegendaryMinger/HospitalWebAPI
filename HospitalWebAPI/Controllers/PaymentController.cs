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
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для получения списка платежей</remarks>
		[HttpGet(nameof(GetPaymentsAsync))]
		public async Task<ActionResult> GetPaymentsAsync(CancellationToken cancellationToken)
		{
			var payments = await _paymentService.GetAllAsync(cancellationToken);
			return Ok(payments);
		}
		/// <summary>
		/// Платеж
		/// </summary>
		/// <param name="id">Id платежа</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для получения платежа по Id</remarks>
		[HttpGet(nameof(GetPaymentByIdAsync))]
		public async Task<ActionResult> GetPaymentByIdAsync(int id, CancellationToken cancellationToken)
		{
			var payment = await _paymentService.GetEntryByIdAsync(id, cancellationToken);
			return Ok(payment);
		}
		/// <summary>
		/// Создание платежа
		/// </summary>
		/// <param name="payment">Платеж</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для создания платежа</remarks>
		[HttpPost(nameof(CreatePaymentAsync))]
		public async Task<ActionResult> CreatePaymentAsync([FromBody] Payment payment, CancellationToken cancellationToken)
		{
			var createdPayment = await _paymentService.CreateEntryAsync(payment, cancellationToken);
			return Ok(createdPayment);
		}
		/// <summary>
		/// Обновление платежа
		/// </summary>
		/// <param name="id">Id платежа</param>
		/// <param name="payment">Платеж</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для обновления платежа</remarks>
		[HttpPut(nameof(UpdatePaymentAsync))]
		public async Task<ActionResult> UpdatePaymentAsync(int id, [FromBody] Payment payment, CancellationToken cancellationToken)
		{
			var updatedPayment = await _paymentService.UpdateEntryAsync(payment, cancellationToken);
			return Ok(updatedPayment);
		}
		/// <summary>
		/// Удаление платежа
		/// </summary>
		/// <param name="id">Id платежа</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <remarks>Запрос для удаления платежа</remarks>
		[HttpDelete(nameof(DeletePaymentAsync))]
		public async Task<ActionResult> DeletePaymentAsync(int id, CancellationToken cancellationToken)
		{
			await _paymentService.DeleteEntryAsync(id, cancellationToken);
			return Ok();
		}
	}
}
