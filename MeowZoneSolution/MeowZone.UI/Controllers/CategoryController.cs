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

		[HttpGet]
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

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(Guid categoryId)
		{
			var category = await _categoryGetterService.GetCategoryByCategoryId(categoryId);
			if (category == null)
			{
				return NotFound();
			}

			await _categoryDeleterService.DeleteCategory(categoryId);
			return RedirectToAction(nameof(ShowCategories));
		}

		[HttpGet]
		public async Task<IActionResult> EditCategory(Guid categoryId)
		{
			var category = await _categoryGetterService.GetCategoryByCategoryId(categoryId);
			if (category == null)
			{
				return NotFound();
			}

			var categoryUpdateRequest = new CategoryUpdateRequest()
			{
				Id = category.Id,
				Name = category.Name,
				Description = category.Description
			};

			return View(categoryUpdateRequest);
		}

		[HttpPost]
		public async Task<IActionResult> EditCategory(CategoryUpdateRequest categoryUpdateRequest)
		{
			if (!ModelState.IsValid)
			{
				return View(categoryUpdateRequest);
			}

			var category = await _categoryGetterService.GetCategoryByCategoryId(categoryUpdateRequest.Id);
			if (category == null)
			{
				return NotFound();
			}

			await _categoryUpdaterService.UpdateCategory(categoryUpdateRequest);

			return RedirectToAction(nameof(ShowCategories));
		}
	}
}
