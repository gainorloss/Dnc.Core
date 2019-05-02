using Dnc.Output;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc
{
    public static class OutputExtensions
    {
        public static FrameworkConstruction UseConsoleOutputHelper(this FrameworkConstruction construction)
        {
            construction.Services.AddSingleton<IConsoleOutputHelper, ConsoleOutputHelper>();
            return construction;
        }
    }
}
