using Dnc.ViewEngines;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc
{
    public static class ViewEngineExtensions
    {
        /// <summary>
        /// Gets it from a <see cref="IViewEngine"/>.
        /// </summary>
        /// <param name="construction"></param>
        /// <returns></returns>
        internal static FrameworkConstruction UseViewEngine(this FrameworkConstruction construction)
        {
            construction.Services.AddSingleton<IViewEngine, RazorViewEngine>();
            return construction;
        }
    }
}
