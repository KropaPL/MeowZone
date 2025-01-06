using MeowZone.Core.Domain.IdentityEntities;
using MeowZone.Core.DTO;
using MeowZone.Core.ServiceContracts;
using MeowZone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MeowZone.UI.Controllers
{
	[Route("[controller]/[action]")]
	public class CatController : Controller
	{
		private readonly ICatsGetterService _catsGetterService;
		private readonly ICatsUpdaterService _catsUpdaterService;
		private readonly ICatsAdderService _catsAdderService;
		private readonly ICatsDeleterService _catsDeleterService;

		private readonly UserManager<ApplicationUser> _userManager;

		public CatController(ICatsAdderService catsAdderService, ICatsUpdaterService catsUpdaterService,
			ICatsDeleterService catsDeleterService, ICatsGetterService catsGetterService, UserManager<ApplicationUser> userManager)
		{
			_catsDeleterService = catsDeleterService;
			_catsAdderService = catsAdderService;
			_catsGetterService = catsGetterService;
			_catsUpdaterService = catsUpdaterService;

			_userManager = userManager;

		}

		[HttpGet]
		public IActionResult CreateCat()
		{
			return View(new CatAddRequest());
		}

		[HttpPost]
		public async Task<IActionResult> CreateCat(CatAddRequest catAddRequest)
		{
			if (!ModelState.IsValid)
			{
				return View(catAddRequest);
			}

			var user = await _userManager.GetUserAsync(User);
			var userId = user.Id;


			await _catsAdderService.AddCat(catAddRequest, userId);
			return RedirectToAction(nameof(ShowCats));
		}

		[HttpPost]
		public async Task<IActionResult> DeleteCat(Guid catId)
		{
			// Ensure the cat exists and belongs to the current user
			var cat = await _catsGetterService.GetCatByCatId(catId);
			if (cat == null)
			{
				return NotFound();  // If no cat found, return 404 Not Found
			}

			// Call the service to delete the cat
			await _catsDeleterService.DeleteCat(catId);

			// Redirect to the ShowCats page after deletion
			return RedirectToAction(nameof(ShowCats));
		}

		[HttpGet]
		public async Task<IActionResult> EditCat(Guid catId)
		{
			// Retrieve the cat to be edited
			var cat = await _catsGetterService.GetCatByCatId(catId);
			if (cat == null)
			{
				return NotFound();  // If the cat is not found, return 404
			}

			// Pass the cat data to the view for editing
			var catUpdateRequest = new CatUpdateRequest
			{
				Id = cat.Id,
				Name = cat.Name,
				Age = cat.Age,
				Breed = cat.Breed,
				Color = cat.Color,
				Gender = cat.Gender,
				Weight = cat.Weight
			};

			return View(catUpdateRequest);  // Pass the model with current cat data
		}

		[HttpPost]
		public async Task<IActionResult> EditCat(CatUpdateRequest catEditRequest)
		{
			if (!ModelState.IsValid)
			{
				return View(catEditRequest);  // If model is invalid, re-render the edit page with the data
			}

			// Retrieve the existing cat from the database
			var cat = await _catsGetterService.GetCatByCatId(catEditRequest.Id);
			if (cat == null)
			{
				return NotFound();  // If the cat is not found, return 404
			}

			// Update the cat's properties here if needed
			await _catsUpdaterService.UpdateCat(catEditRequest);

			// Redirect to the ShowCats page after editing
			return RedirectToAction(nameof(ShowCats));
		}




		public async Task<IActionResult> ShowCats()
		{
			var user = await _userManager.GetUserAsync(User);
			var userId = user.Id;
			var cats = await _catsGetterService.getAllUserCats(userId);

			return View(cats);
		}
	}
}
