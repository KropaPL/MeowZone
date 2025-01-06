using MeowZone.Core.DTO;
using MeowZone.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace MeowZone.UI.Controllers
{
	[Route("[controller]/[action]")]
	public class CategoryController : Controller
	{
		private readonly ICategoryAdderService _categoryAdderService;
		private readonly ICategoryGetterService _categoryGetterService;
		private readonly ICategoryDeleterService _categoryDeleterService;
		private readonly ICategoryUpdaterService _categoryUpdaterService;

		public CategoryController(ICategoryAdderService categoryAdderService, ICategoryGetterService categoryGetterService,
			ICategoryDeleterService categoryDeleterService, ICategoryUpdaterService categoryUpdaterService)
		{
			_categoryAdderService = categoryAdderService;
			_categoryGetterService = categoryGetterService;
			_categoryDeleterService = categoryDeleterService;
			_categoryUpdaterService = categoryUpdaterService;
		}
		public async Task<IActionResult> ShowCategories()
		{
			var categories = await _categoryGetterService.GetAllCategories();

			return View(categories);
		}

		[HttpGet]
		public IActionResult CreateCategory()
		{
			return View(new CategoryAddRequest());
		}

		[HttpPost]
		public async Task<IActionResult> CreateCategory(CategoryAddRequest categoryAddRequest)
		{
			if (!ModelState.IsValid)
			{
				return View(categoryAddRequest);
			}

			await _categoryAdderService.AddCategory(categoryAddRequest);

			return RedirectToAction(nameof(ShowCategories));
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
