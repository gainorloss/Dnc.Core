using Dnc.AspNetCore.Controllers;
using Dnc.AspNetCore.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.AspNetCore.Filters
{
    /// <summary>
    /// Global exception handlers.
    /// </summary>
    public class ApiGlobalLogExceptionFilter
        : IExceptionFilter
    {
        private readonly IHostingEnvironment _env;
        private readonly ILogger<ApiGlobalLogExceptionFilter> _logger;
        public ApiGlobalLogExceptionFilter(ILogger<ApiGlobalLogExceptionFilter> logger, IHostingEnvironment env)
        {
            _logger = logger;
            _env = env;
        }
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
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

                if (_env.IsDevelopment())
                {
                    //In development,output exception message.
                    filterContext.Result = new BadRequestObjectResult(new AjaxResult(false, HttpStatusCodes.BadRequest, $"系统出现异常，请联系管理员,错误详情:{excep.Message}"));
                }
                else
                {
                    filterContext.Result = new BadRequestObjectResult(new AjaxResult(false, HttpStatusCodes.BadRequest, "系统出现异常，请联系管理员"));
                }
                filterContext.ExceptionHandled = true;//Tag it is handled.
            }
        }
    }
    internal class InternalServerErrorObjectResult : ObjectResult
    {
        public InternalServerErrorObjectResult(object val)
            : base(val)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }
    }

}
