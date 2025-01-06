using MeowZone.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace MeowZone.UI.Controllers
{
	[Route("[controller]/[action]")]
	public class BarfController : Controller
	{
		private readonly ICatsGetterService _catsGetterService;
		private readonly IBarfCalculator _barfCalculator;

		public BarfController(ICatsGetterService catsGetterService, IBarfCalculator barfCalculator)
		{
			_catsGetterService = catsGetterService;
			_barfCalculator = barfCalculator;
		}


		[HttpGet]
		public async Task<IActionResult> ShowBarf(Guid catId)
		{
			var cat = await _catsGetterService.GetCatByCatId(catId);

			if (cat == null)
			{
				return NotFound();
			}

			var barfResult = await _barfCalculator.CalculateBarf(cat);

			return View(barfResult);
		}
	}
}
