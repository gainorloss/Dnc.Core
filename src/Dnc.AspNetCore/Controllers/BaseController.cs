using Dnc.AspNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.AspNetCore.Controllers
{
    public class BaseController:ControllerBase
    {

        public IActionResult Ajax(StatusCode statusCode,
            object data = null,
            string msg = null)
        {
            return new JsonResult(new AjaxResult()
            {
                Status = statusCode == Models.StatusCode.Ok,
                Code = statusCode,
                Msg = msg,
                Data = data
            });
        }
    }
}
