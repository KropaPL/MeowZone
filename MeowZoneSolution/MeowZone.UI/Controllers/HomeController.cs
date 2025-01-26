using Microsoft.AspNetCore.Mvc;

namespace MeowZone.Controllers
{

    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        [HttpGet]
        [Route("[action]")]
        [Route("/")]
        public IActionResult Index()
        {

            return View();
        }
    }
}
