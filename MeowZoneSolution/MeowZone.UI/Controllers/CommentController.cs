using MeowZone.Core.DTO;
using Microsoft.AspNetCore.Mvc;

namespace MeowZone.UI.Controllers
{
	[Route("[controller]/[action]")]
	public class CommentController : Controller
	{
		[HttpGet]
		public async Task<IActionResult> AddComment()
		{
			return View(new CommentAddRequest());
		}
	}
}
