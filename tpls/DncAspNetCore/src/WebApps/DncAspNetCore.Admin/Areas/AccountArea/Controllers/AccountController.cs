using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DncAspNetCore.Admin.Areas.AccountArea.Controllers
{
    [Area(nameof(AccountArea))]
    public class AccountController : Controller
    {
        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult DoSignIn()
        {
            return View();
        }
    }
}
