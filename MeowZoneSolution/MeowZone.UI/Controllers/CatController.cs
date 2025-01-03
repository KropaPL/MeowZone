using Microsoft.AspNetCore.Mvc;

namespace MeowZone.UI.Controllers
{
	public class CatController : Controller
	{
		public IActionResult CreateCat()
		{
			return View();
		}

		public IActionResult DeleteCat()
		{
			return View();
		}
		public IActionResult EditCat()
		{
			return View();
		}

		public IActionResult ShowCats()
		{
			return View();
		}
	}
}
