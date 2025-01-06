using Microsoft.AspNetCore.Mvc;

namespace MeowZone.UI.Controllers
{
	public class PostController : Controller
	{
		public IActionResult CreatePost()
		{
			return View();
		}
		public IActionResult EditPost()
		{
			return View();
		}

		public IActionResult DeletePost()
		{
			return View();
		}

		public IActionResult ShowPost()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> ListPostsAccordingToCategory(Guid categoryId)
		{
			return View();
		}

		public IActionResult ListPosts()
		{
			return View();
		}
	}
}
