using Dnc.Alarmers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc
{
    internal static class AlarmerExtensions
    {
        public static FrameworkConstruction UseAlarmer(this FrameworkConstruction construction)
        {
            construction.Services.AddSingleton<IAlarmer, Alarmer>();
            return construction;
        }
    }
}
