using HospitalWebAPI.Classes;
using HospitalWebAPI.Middlewares.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Security;
using System.Text.Json;

namespace HospitalWebAPI.Middlewares
{
	public class ExceptionHandlingMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<ExceptionHandlingMiddleware> _logger;
		public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
		{
			_next = next;
			_logger = logger;
		}
		public async Task InvokeAsync(HttpContext httpContext)
		{
			try
			{
				await _next(httpContext);
			}
			// Общие исключения
			catch (ArgumentNullException ex)
			{
				await HandleExceptionAsync(httpContext, ex.Message, HttpStatusCode.BadRequest, "Some arguments are NULL");
			}
			catch (ArgumentException ex)
			{
				await HandleExceptionAsync(httpContext, ex.Message, HttpStatusCode.BadRequest, "Some arguments are missing or contain invalid values");
			}
			// Исключения генерации Excel-документов
			catch (EntryIsNullException ex)
			{
				await HandleExceptionAsync(httpContext, ex.Message, HttpStatusCode.Conflict, "List of this entries is NULL");
			}
			// Исключения авторизации и регистрации
			catch (AuthorizationException ex)
			{
				await HandleExceptionAsync(httpContext, ex.Message, HttpStatusCode.Conflict, "Invalid login or password");
			}
			catch (UserArleadyExistsException ex)
			{
				await HandleExceptionAsync(httpContext, ex.Message, HttpStatusCode.Conflict, "User arleady exists");
			}
			catch (PasswordConfirmationException ex)
			{
				await HandleExceptionAsync(httpContext, ex.Message, HttpStatusCode.Conflict, "Passwords do not match");
			}
			// Глобальное исключение
			catch (Exception ex)
			{
				await HandleExceptionAsync(httpContext, ex.Message, HttpStatusCode.InternalServerError, "Internal server error");
			}
		}
		private async Task HandleExceptionAsync(HttpContext context, string exMessage, HttpStatusCode httpStatusCode, string message)
		{
			_logger.LogError(exMessage);

			HttpResponse response = context.Response;

			response.ContentType = "application/json";
			response.StatusCode = (int)httpStatusCode;

			ErrorDataTranferObject errorDto = new()
			{
				StatusCode = (int)httpStatusCode,
				Message = message
			};

			string result = JsonSerializer.Serialize(errorDto);

			await response.WriteAsJsonAsync(result);
		}
	}
}
