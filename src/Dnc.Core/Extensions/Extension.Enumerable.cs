using Humanizer;
using System.Collections.Generic;
using System.Linq;

namespace Dnc
{
    /// <summary>
    /// Extension methods for a <see cref="IEnumerable{T}"/>
    /// </summary>
    public static class EnumerableExtensions
    {
        public static string ToHumanization<T>(this IEnumerable<T> collection)
        {
            if (collection == null)
                throw new System.ArgumentNullException(nameof(collection));

            var props = typeof(T).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            var propMaxLength = props.Max(p => p.Name.Length);

            return collection.Humanize(t =>
            {
                var output = string.Empty;
                foreach (var prop in props)
                {
                    var propValue = prop.GetValue(t);
                    output = $"{output}\r\n{prop.Name.PadLeft(propMaxLength, ' ')}:{propValue}";
                }
                return output;
            });
        }
    }
}
