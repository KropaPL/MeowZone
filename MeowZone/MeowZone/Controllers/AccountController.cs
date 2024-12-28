using Microsoft.AspNetCore.Mvc;

namespace MeowZone.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
