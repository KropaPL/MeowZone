using MeowZone.Core.Domain.IdentityEntities;
using MeowZone.Core.DTO;
using MeowZone.Core.ServiceContracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MeowZone.UI.Controllers
{
	[Route("[controller]/[action]")]
	public class PostController : Controller
	{
		private readonly IPostsAdderService _postsAdderService;
		private readonly IPostsDeleterService _postsDeleterService;
		private readonly IPostsGetterService _postsGetterService;
		private readonly IPostsUpdaterService _postsUpdaterService;

		private readonly ICategoryGetterService _categoryGetterService;


		private readonly UserManager<ApplicationUser> _userManager;

		public PostController(UserManager<ApplicationUser> userManager, IPostsDeleterService postsDeleterService, IPostsAdderService postsAdderService, IPostsGetterService postsGetterService, IPostsUpdaterService postsUpdaterService, ICategoryGetterService categoryGetterService)
		{
			_userManager = userManager;
			_postsDeleterService = postsDeleterService;
			_postsGetterService = postsGetterService;
			_postsUpdaterService = postsUpdaterService;
			_postsAdderService = postsAdderService;
			_categoryGetterService = categoryGetterService;
		}

		[HttpGet]
		public async Task<IActionResult> CreatePost(Guid categoryId)
		{
			var user = await _userManager.GetUserAsync(User);
			var userId = user.Id;

			return View(new PostAddRequest()
			{
				CategoryId = categoryId,
				AuthorId = userId
			});
		}

		[HttpPost]
		public async Task<IActionResult> CreatePost(PostAddRequest postAddRequest)
		{
			if (!ModelState.IsValid)
			{
				return View(postAddRequest);
			}

			await _postsAdderService.AddPost(postAddRequest, postAddRequest.AuthorId, postAddRequest.CategoryId);

			return RedirectToAction(nameof(ListPostsAccordingToCategory), "Post", new { categoryId = postAddRequest.CategoryId });
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
			var posts = await _postsGetterService.getAllPostsbyCategoryId(categoryId);
			var categoryResponse = (await _categoryGetterService.GetCategoryByCategoryId(categoryId));
			ViewBag.Category = categoryResponse.Name;
			ViewBag.CategoryId = categoryId;

			return View(posts);
		}

		public IActionResult ListPosts()
		{
			return View();
		}
	}
}
