using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DncAspNetCore.Admin.Areas.AdminArea.Controllers
{
    [Area(nameof(AdminArea))]
    public class SysRolesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
