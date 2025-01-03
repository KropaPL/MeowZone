using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace MeowZone.UI.Controllers
{
	[Route("[controller]/[action]")]
	public class CategoryController : Controller
	{
		public IActionResult ShowCategories()
		{
			return View();
		}

		public IActionResult CreateCategory()
		{
			return View();
		}

		public IActionResult DeleteCategory()
		{
			return View();
		}
		public IActionResult EditCategory()
		{
			return View();
		}
	}
}
