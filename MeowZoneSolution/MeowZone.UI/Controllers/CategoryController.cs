using Microsoft.AspNetCore.Mvc;

namespace MeowZone.UI.Controllers
{
	[Route("[controller]/[action]")]
	public class CategoryController : Controller
	{
		public IActionResult ShowCategories()
		{
			return View();
		}
	}
}
