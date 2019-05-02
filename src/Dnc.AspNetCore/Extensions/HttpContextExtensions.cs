using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.AspNetCore.Extensions
{
    /// <summary>
    /// Httpcontext extensions.
    /// </summary>
    public static class HttpContextExtensions
    {
        /// <summary>
        /// Set cookies.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="days"></param>
        public static void SetCookies(this HttpContext context, string key, string value, int days = 30 * 6)
        {
            context.Response.Cookies.Append(key, value, new CookieOptions()
            {
                Expires = DateTimeOffset.Now.AddDays(days)
            });
        }

        /// <summary>
        /// Set generic value to cookies.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="days"></param>
        public static void SetCookies<T>(this HttpContext context, string key, T value, int days = 30 * 6)
            where T : class, new()
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }
            var cookieStr = JsonConvert.SerializeObject(value);
            context.Response.Cookies.Append(key, cookieStr, new CookieOptions()
            {
                Expires = DateTimeOffset.Now.AddDays(days)
            });
        }

        /// <summary>
        /// Get cookies.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetCookies(this HttpContext context, string key)
        {
            var bExisted = context.Request.Cookies.TryGetValue(key, out string value);
            return bExisted ? value : null;
        }

        /// <summary>
        /// Get generic value from cookies.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetCookies<T>(this HttpContext context, string key)
            where T : class, new()
        {
            var bExisted = context.Request.Cookies.TryGetValue(key, out string value);
            return bExisted ? JsonConvert.DeserializeObject<T>(value) : default(T);
        }
    }
}
