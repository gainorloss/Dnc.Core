using Dnc.SeedWork;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc
{

    /// <summary>
    /// Extension methods for module <see cref="SeedWork"/>
    /// </summary>
    internal static class SeedWorkExtensions
    {
        public static FrameworkConstruction UseMockRepository(this FrameworkConstruction construction)
        {
            construction.Services.AddSingleton<IMockRepository, GenFuMockRepository>();
            return construction;
        }
    }
}
