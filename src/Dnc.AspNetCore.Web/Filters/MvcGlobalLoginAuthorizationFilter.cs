using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Dnc.AspNetCore.Web
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class MvcGlobalLoginAuthorizationFilter
        : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        private readonly IHostingEnvironment _env;
        private readonly HttpContext _ctx;
        private readonly UrlEncoder _urlEncoder;
        public MvcGlobalLoginAuthorizationFilter(
            IHostingEnvironment env,
            IHttpContextAccessor accessor,
            UrlEncoder urlEncoder)
        {
            _env = env;
            _ctx = accessor.HttpContext;
            _urlEncoder = urlEncoder;
        }
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (context.ActionDescriptor.FilterDescriptors.Any(f => f.Filter.GetType() == typeof(AllowAnonymousFilter)))
                return;
            var rt = await _ctx.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (rt.Succeeded)
                return;

            var request = context.HttpContext.Request;
            var returnUrl = $"{request.Path}{request.QueryString}";

            var url = $"/AccountArea/Account/SignIn?returnUrl={_urlEncoder.Encode(returnUrl)}";
            context.Result = new RedirectResult(url);
            return;
        }
    }

}
