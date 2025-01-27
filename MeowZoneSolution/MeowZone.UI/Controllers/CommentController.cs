using MeowZone.Core.Domain.Entities;
using MeowZone.Core.Domain.IdentityEntities;
using MeowZone.Core.DTO;
using MeowZone.Core.ServiceContracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MeowZone.UI.Controllers
{
	[Route("[controller]/[action]")]
	public class CommentController : Controller
	{
		private readonly ICommentAdderService _commentAdderService;
		private readonly ICommentDeleterService _commentDeleterService;
		private readonly ICommentGetterService _commentGetterService;
		private readonly ICommentUpdaterService _commentUpdaterService;

		private readonly IPostsGetterService _postsGetterService;

		private readonly UserManager<ApplicationUser> _userManager;

		public CommentController(ICommentAdderService commentAdderService, ICommentDeleterService commentDeleterService, ICommentGetterService commentGetterService, ICommentUpdaterService commentUpdaterService, IPostsGetterService postsGetterService, UserManager<ApplicationUser> userManager)
		{
			_commentAdderService = commentAdderService;
			_commentDeleterService = commentDeleterService;
			_commentGetterService = commentGetterService;
			_commentUpdaterService = commentUpdaterService;
			_postsGetterService = postsGetterService;
			_userManager = userManager;
		}

		[HttpGet]
		public async Task<IActionResult> EditComment(Guid commentId, Guid postId)
		{
			@ViewBag.postId = postId;

			var comment = await _commentGetterService.GetCommentByCommentId(commentId);
			if (comment == null)
			{
				return NotFound();
			}

			var commentUpdateRequest = new CommentUpdateRequest()
			{
				Id = comment.Id,
				CommentContent = comment.CommentContent
			};

			return View(commentUpdateRequest);
		}

		[HttpPost]
		public async Task<IActionResult> EditComment(CommentUpdateRequest commentUpdateRequest, Guid postId)
		{
			if (!ModelState.IsValid)
			{
				return View(commentUpdateRequest);
			}

			var comment = await _commentGetterService.GetCommentByCommentId(commentUpdateRequest.Id);
			if (comment == null)
			{
				return NotFound();
			}

			await _commentUpdaterService.UpdateComment(commentUpdateRequest);

		return RedirectToAction(nameof(GoToComments), "Comment", new { id = postId });
	}

		[HttpDelete]
		public async Task<IActionResult> DeleteComment(Guid commentId, Guid postId)
		{
			var comment = await _commentGetterService.GetCommentByCommentId(commentId);
			if (comment == null)
			{
				return NotFound();
			}

			await _commentDeleterService.DeleteComment(commentId);
			return RedirectToAction(nameof(GoToComments), "Comment", new { id = postId});
		}

		[HttpPost]
		public async Task<IActionResult> AddComment(CommentAddRequest commentAddRequest)
		{
			if (!ModelState.IsValid)
			{
				var post = await _postsGetterService.GetPostByPostId(commentAddRequest.PostId);
				return RedirectToAction(nameof(GoToComments), "Comment", new { id = commentAddRequest.PostId });
			}

			var user = await _userManager.GetUserAsync(User);
			var userId = user.Id;

			await _commentAdderService.AddComment(commentAddRequest, userId, commentAddRequest.PostId);

			return RedirectToAction(nameof(GoToComments), "Comment", new { id = commentAddRequest.PostId });
		}



		[HttpGet]
		public async Task<IActionResult> GoToComments(Guid id)
		{
			var post = await _postsGetterService.GetPostByPostId(id);
			var comments = await _commentGetterService.getAllCommentsbyPostId(id);

			comments = comments.OrderBy(temp => temp.CreatedAt).ToList();

			// Fetch usernames for each comment
			foreach (var comment in comments)
			{
				var user = await _userManager.FindByIdAsync(comment.AuthorId.ToString());
				comment.AuthorName = user?.UserName ?? "Unknown";  // Fallback if user not found
			}

			var viewModel = new CommentAddRequest()
			{
				PostId = post.Id,
			};

			ViewBag.comments = comments;
			ViewBag.PostTitle = post.Title;
			ViewBag.CreatedAt = post.CreatedAt;
			ViewBag.Content = post.Content;

			return View(viewModel);
		}




	}
}
