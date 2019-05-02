using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Extensions
{
    /// <summary>
    /// Extension methods for array.
    /// </summary>
    public static class ArrayExtensions
    {
        /// <summary>
        /// Append some to the array end.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="toAdd"></param>
        /// <returns></returns>
        public static T[] Append<T>(this T[] source, params T[] toAdd)
        {
            var items = new List<T>(source);
            items.AddRange(toAdd);
            return items.ToArray();
        }


        /// <summary>
        /// Prepend some to the arry start.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="toAdd"></param>
        /// <returns></returns>
        public static T[] Prepend<T>(this T[] source, params T[] toAdd)
        {
            var items = new List<T>(toAdd);
            items.AddRange(source);
            return items.ToArray();
        }


        /// <summary>
        /// Assert arry is null or empty;
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this T[] source)
        {
            return source == null || source.Length <= 0;
        }
    }
}
