using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DncAspNetCore.Admin.Areas.AdminArea.Controllers
{
    [Area(nameof(AdminArea))]
    public class SysUsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
