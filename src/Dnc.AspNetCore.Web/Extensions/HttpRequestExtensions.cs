using Microsoft.AspNetCore.Http;

namespace Dnc.AspNetCore.Web
{
    /// <summary>
    /// Http request extension.
    /// </summary>
    public static class HttpRequestExtensions
    {
        public static bool IsAjaxRequest(this HttpRequest req)
        {
            bool result = false;

            var xreq = req.Headers.ContainsKey("x-requested-with");
            if (xreq)
            {
                result = req.Headers["x-requested-with"] == "XMLHttpRequest";
            }

            return result;
        }
    }

}
