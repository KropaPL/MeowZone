using MeowZone.Core.Domain.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MeowZone.UI.Controllers
{
	public class PostController : Controller
	{

		private readonly UserManager<ApplicationUser> _userManager;

		public PostController(UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
		}
		public IActionResult CreatePost(Guid categoryId)
		{
			return View();
		}
		public IActionResult EditPost()
		{
			return View();
		}

		[HttpPost]
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
