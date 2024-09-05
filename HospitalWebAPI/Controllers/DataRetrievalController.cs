using HospitalWebAPI.Contexts;
using HospitalWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalWebAPI.Controllers
{
	[Route("WebAPI/DataRetrievalController")]
	public class DataRetrievalController : Controller
	{
		[Route("Gender")]
		[HttpGet]
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
	}
}
