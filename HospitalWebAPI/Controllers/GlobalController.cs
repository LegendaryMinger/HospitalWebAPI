using HospitalWebAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalWebAPI.Controllers
{
	[Authorize]
	[Route("/[controller]")]
	public class GlobalController : Controller
	{
		private readonly IGlobalService _globalService;
		public GlobalController(IGlobalService globalService)
		{
			_globalService = globalService;
		}
		/// <summary>
		/// Общий Excel отчет
		/// </summary>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <returns></returns>
		/// <remarks>Запрос для получения Excel-файла по всем сущностям БД</remarks>
		[HttpGet(nameof(GetGlobalExcelFileAsync))]
		public async Task<FileResult> GetGlobalExcelFileAsync(CancellationToken cancellationToken)
		{
			var file = await _globalService.GetGlobalExcelFileAsync(cancellationToken);
			return File(file.File.ToArray(), file.ContentType, file.FileName);
		}
	}
}
