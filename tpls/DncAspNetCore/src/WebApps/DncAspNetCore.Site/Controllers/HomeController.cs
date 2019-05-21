using DncAspNetCore.Site.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace DncAspNetCore.Site.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient()
            {
                BaseAddress = new System.Uri("http://localhost:8000"),
            };
            var access_token = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            ViewData["access_token"] = access_token;

            client.SetBearerToken(access_token);
            var str = await client.GetStringAsync("/api/values");
            ViewData["api"] = str;
            return View();
        }

        public IActionResult Privacy()
        {
            return View(HttpContext.User.Claims);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
