using HospitalWebAPI.Classes;
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
			catch (UnauthorizedAccessException ex)
			{
				await HandleExceptionAsync(httpContext, ex.Message, HttpStatusCode.Unauthorized, "Invalid login or password");
			}
			catch (BadHttpRequestException ex)
			{
				await HandleExceptionAsync(httpContext, ex.Message, HttpStatusCode.Unauthorized, "Bad request");
			}
			catch (ArgumentNullException ex)
			{
				await HandleExceptionAsync(httpContext, ex.Message, HttpStatusCode.BadRequest, "Some fields may be NULL");
			}
			catch (SecurityException ex)
			{
				await HandleExceptionAsync(httpContext, ex.Message, HttpStatusCode.Conflict, "User arleady exists");
			}
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
