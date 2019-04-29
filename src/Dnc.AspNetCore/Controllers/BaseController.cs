using Dnc.AspNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.AspNetCore.Controllers
{
    public class BaseController
    {
        //public UserIdentity UserIdentity
        //{
        //    get
        //    {
        //        return User.ToUserIdentity();
        //    }
        //}

        public IActionResult Ajax(StatusCode statusCode,
            object data = null,
            string msg = null)
        {
            return new JsonResult(new AjaxResult()
            {
                Status = statusCode == StatusCode.Ok,
                Code = statusCode,
                Msg = msg,
                Data = data
            });
        }
    }
}
