using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DncAspNetCore.Admin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Desktop()
        {
            return View();
        }
        public IActionResult Statis()
        {
            return View();
        }
    }
}
