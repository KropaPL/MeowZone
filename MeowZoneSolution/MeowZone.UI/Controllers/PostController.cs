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

		[HttpGet]
		public async Task<IActionResult> EditPost(Guid postId)
		{
			var post = await _postsGetterService.GetPostByPostId(postId);
			if (post == null)
			{
				return NotFound();
			}

			var postUpdateRequest = new PostUpdateRequest()
			{
				Id = post.Id,
				Content = post.Content,
				Title = post.Title
			};

			ViewBag.CategoryId = post.CategoryId;
			ViewBag.AuthorId = post.AuthorId;

			return View(postUpdateRequest);
		}

		[HttpPost]
		public async Task<IActionResult> EditPost(PostUpdateRequest postUpdateRequest)
		{
			if (!ModelState.IsValid)
			{
				return View(postUpdateRequest);
			}

			var post = await _postsGetterService.GetPostByPostId(postUpdateRequest.Id);
			if (post == null)
			{
				return NotFound();
			}

			await _postsUpdaterService.UpdatePost(postUpdateRequest);

			return RedirectToAction(nameof(ListPostsAccordingToCategory), "Post", new { categoryId = post.CategoryId });
		}

		[HttpPost]
		public async Task<IActionResult> DeletePost(Guid postId, Guid categoryId)
		{
			var post = await _postsGetterService.GetPostByPostId(postId);
			if (post == null)
			{
				return NotFound();
			}

			await _postsDeleterService.DeletePost(postId);

			return RedirectToAction(nameof(ListPostsAccordingToCategory), "Post", new { categoryId = categoryId });
		}


		[HttpGet]
		public async Task<IActionResult> ListPostsAccordingToCategory(Guid categoryId)
		{
			var posts = await _postsGetterService.getAllPostsbyCategoryId(categoryId);
			posts = posts.OrderBy(temp => temp.CreatedAt).ToList();
			var categoryResponse = (await _categoryGetterService.GetCategoryByCategoryId(categoryId));

			foreach (var post in posts)
			{
				var user = await _userManager.FindByIdAsync(post.AuthorId.ToString());
				post.AuthorName = user?.UserName ?? "Unknown";  // Fallback if user not found
			}

			ViewBag.Category = categoryResponse.Name;
			ViewBag.CategoryId = categoryId;

			return View(posts);
		}
	}
}
