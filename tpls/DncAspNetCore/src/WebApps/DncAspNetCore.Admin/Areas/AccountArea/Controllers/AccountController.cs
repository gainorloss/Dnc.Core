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

namespace DncAspNetCore.Admin.Areas.AccountArea.Controllers
{
    [Area(nameof(AccountArea))]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        public IActionResult SignIn(string returnUrl=null)
        {
            ViewData["returnUrl"] = returnUrl;
            return View();
        }

        public async Task<IActionResult> DoSignInAsync(string name,string token,string verifycode,bool remember,string returnUrl=null)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, name),
                new Claim(ClaimTypes.Email, string.Empty),
                new Claim(ClaimTypes.MobilePhone, string.Empty),
                new Claim(ClaimTypes.Gender, string.Empty),
                new Claim(ClaimTypes.Sid, "1"),
                new Claim("shopId", string.Empty),
                new Claim("avatar", string.Empty)
            };

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaims(claims);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties()
                {
                    IsPersistent = remember,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7)
                });

            return Ok();
        }
    }
}
