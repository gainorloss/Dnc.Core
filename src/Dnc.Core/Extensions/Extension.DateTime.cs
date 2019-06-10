
using Humanizer;
using System;

namespace Dnc
{
    /// <summary>
    /// Extension methods for a <see cref="DateTime"/>.
    /// </summary>
    public static class DateTimeExtensions
    {
        public static string ToHumanization(this DateTime time) => time.Humanize();
    }
}
