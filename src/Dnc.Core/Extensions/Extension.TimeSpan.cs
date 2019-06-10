using Humanizer;
using System;

namespace Dnc
{
    /// <summary>
    /// Extension methods for a <see cref="TimeSpan"/>.
    /// </summary>
    public static class TimeSpanExtensions
    {
        public static string ToHumanization(this TimeSpan timeSpan) => timeSpan.Humanize();
    }
}
