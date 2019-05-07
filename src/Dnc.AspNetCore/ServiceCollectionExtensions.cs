using Dnc.AspNetCore.Controllers;
using Dnc.AspNetCore.Filters;
using LogDashboard;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dnc.AspNetCore
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// apidoc,api versioning,global log exception filter,log dashboard "/logdashboard".
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddAspNetCore(this IServiceCollection services, AspNetCoreType aspNetCoreType = AspNetCoreType.Api)
        {
            if (aspNetCoreType == AspNetCoreType.Api)
            {
                services.AddSwaggerAPIDoc();
                services.AddAPIVersion();
            }

            services.AddLogDashboard();

            services.AddMvc(opt =>
            {
                if (aspNetCoreType == AspNetCoreType.Api)
                {
                    opt.Filters.Add<ApiGlobalLogExceptionFilter>();
                }
                else
                {
                    opt.Filters.Add<MvcGlobalLogExceptionFilter>();
                    opt.Filters.Add<MvcGlobalLoginAuthorizationFilter>();
                }
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            #region 永远不要相信用户输入
            //关闭默认的ApiBehavior
            services.Configure<ApiBehaviorOptions>(option =>            {
                //使用自己的模型验证返回数据          
                option.InvalidModelStateResponseFactory = (action =>                {                    var errMessages = action.ModelState.Values.SelectMany(v => v.Errors).Select(g => g.ErrorMessage).Aggregate((i, next) => $"{i}【>_<】{next}");                    return new BadRequestObjectResult(new AjaxResult(false, HttpStatusCodes.BadRequest, errMessages));                });            });
            #endregion
            return services;
        }
    }
}
