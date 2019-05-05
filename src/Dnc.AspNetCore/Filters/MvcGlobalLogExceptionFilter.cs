using Dnc.AspNetCore.Controllers;
using Dnc.AspNetCore.Extensions;
using Dnc.AspNetCore.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.AspNetCore.Filters
{
    public class MvcGlobalLogExceptionFilter
       : IExceptionFilter
    {
        private readonly IHostingEnvironment _env;
        private readonly ILogger<MvcGlobalLogExceptionFilter> _logger;
        public MvcGlobalLogExceptionFilter(IHostingEnvironment env,
            ILogger<MvcGlobalLogExceptionFilter> logger)
        {
            _env = env;
            _logger = logger;
        }
        public void OnException(ExceptionContext filterContext)
        {
            if (!_env.IsDevelopment())
            {
                if (!filterContext.ExceptionHandled)//异常有没有被处理过
                {
                    var excep = filterContext.Exception;
                    var controllerName = filterContext.RouteData.Values["controller"];
                    var actionName = filterContext.RouteData.Values["action"];
                    string tempMsg = $"在请求controller[{controllerName}] 的 action[{actionName}] 时产生异常【{excep.Message}】";
                    if (excep.InnerException != null)
                    {
                        tempMsg = $"{tempMsg} ,内部异常【{excep.InnerException.Message}】。";
                    }
                    if (excep.StackTrace != null)
                    {
                        tempMsg = $"{tempMsg} ,异常堆栈【{excep.StackTrace}】。";
                    }
                    _logger.LogError(tempMsg);//Log.

                    if (filterContext.HttpContext.Request.IsAjaxRequest())//检查请求头
                    {
                        filterContext.Result = new BadRequestObjectResult(
                            new AjaxResult()
                            {
                                Status = true,
                                Code = HttpStatusCodes.BadRequest,
                                Msg = "系统出现异常，请联系管理员",
                            }//这个就是返回的结果
                        );
                    }
                    else
                    {
                        filterContext.Result = new ViewResult()
                        {
                            ViewName = "~/Views/Shared/Error.cshtml",
                        };
                    }
                    filterContext.ExceptionHandled = true;
                }
            }
        }
    }

}
