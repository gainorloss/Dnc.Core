using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DncAspNetCore.Admin.Models;

namespace DncAspNetCore.Admin.Controllers
{
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
