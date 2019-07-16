using Dnc.Biz.Admin;
using Dnc.Seedwork;
using DncAspNetCore.Admin.Infrastructure;
using DncAspNetCore.Admin.Infrastructure.TagHelpers;
using DncAspNetCore.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DncAspNetCore.Admin.Areas.AdminArea.Controllers
{
    [Area(nameof(AdminArea))]
    public class SysUsersController : Controller
    {
        private readonly IMockRepository _mockRepository;
        public SysUsersController(IMockRepository mockRepository)
        {
            _mockRepository = mockRepository;
        }
        public IActionResult Index()
        {
            var items = new List<LayUIDataGridItem>
            {
                new LayUIDataGridItem(null, "搜索", "/admin-area/sys-users/list"),
                new LayUIDataGridItem("q", "创建", "/admin-area/sys-users/create-async", "/admin-area/sys-users/editor"),
                new LayUIDataGridItem("r", "编辑", "/admin-area/sys-users/modify-async", "/admin-area/sys-users/editor"),
                new LayUIDataGridItem("r", "详情", null, "/admin-area/sys-users/detail","blank")
            };
            return View(items);
        }

        public IActionResult List(string name, int page, int limit)
        {
            var users = _mockRepository.CreateMultiple<SysUserVm>();
            return Json(new LayUIOutput(0,data:users));
        }

        public IActionResult Editor()
        {
            return View();
        }
        public IActionResult CreateAsync()
        {
            return Ok();
        }
        public IActionResult ModifyAsync()
        {
            return Ok();
        }
        public IActionResult Detail()
        {
            return View();
        }
    }
}
