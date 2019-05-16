using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Dnc.AspNetCore.Filters
{
    /// <summary>
    /// Staticizes u's pages.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class MvcStaticFileActionFilterAttribute
        : ActionFilterAttribute
    {
        public string Key { get; set; } = "id";
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ViewResult viewResult)
            {
                var sp = context.HttpContext.RequestServices;
                var executor = sp.GetRequiredService<IActionResultExecutor<ViewResult>>() as ViewResultExecutor;
                var opt = sp.GetRequiredService<IOptions<MvcViewOptions>>();

                var viewEngineResult = executor.FindView(context, viewResult);
                viewEngineResult.EnsureSuccessful(originalLocations: null);
                var view = viewEngineResult.View;

                var sb = new StringBuilder();
                using (var sw = new StringWriter(sb))
                {
                    var viewContext = new ViewContext(context, view, viewResult.ViewData, viewResult.TempData, sw, opt.Value.HtmlHelperOptions);
                    view.RenderAsync(viewContext).Wait();
                }
                var tuple = BuildFilePath(context);
                string dir = tuple.dir;
                string file = tuple.file;
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                if (!FileIsEffective(file))
                {
                    using (var sw = new StreamWriter(file, false))
                    {
                        sw.Write(sb.ToString());
                    }
                }
                ContentResult contentResult = BuildContentResult(sb.ToString());
                context.Result = contentResult;
            }
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var tuple = BuildFilePath(context);
            string file = tuple.file;
            if (File.Exists(file) && FileIsEffective(file))
            {
                using (var sr = new StreamReader(file))
                {
                    var content = sr.ReadToEnd();
                    context.Result = BuildContentResult(content);
                }
            }
        }
        private bool FileIsEffective(string file)
        {
            var fileInfo = new FileInfo(file);
            return (DateTime.Now - fileInfo.CreationTime).TotalMinutes <= 2;
        }
        private (string dir, string file) BuildFilePath(FilterContext context)
        {
            var area = context.RouteData.Values.ContainsKey("area") ? context.RouteData.Values["area"].ToString().ToLower() : "default";
            var controller = context.RouteData.Values["controller"].ToString().ToLower();
            var action = context.RouteData.Values["action"].ToString().ToLower();
            var id = context.RouteData.Values.ContainsKey(Key) ? context.RouteData.Values[Key].ToString().ToLower() : string.Empty;
            if (string.IsNullOrWhiteSpace(id) && context.HttpContext.Request.Query.ContainsKey(Key))
            {
                id = context.HttpContext.Request.Query[Key].ToString().ToLower();
            }
            var dir = Path.Combine(AppContext.BaseDirectory, "wwwroot", area);
            var fileName = string.IsNullOrWhiteSpace(id) ? $"{controller}-{action}.html" : $"{controller}-{action}-{id}.html";
            var file = Path.Combine(dir, fileName);
            return (dir: dir, file: file);
        }

        private static ContentResult BuildContentResult(string content)
        {
            var contentResult = new ContentResult();
            contentResult.Content = content;
            contentResult.ContentType = "text/html";
            return contentResult;
        }
    }

}
