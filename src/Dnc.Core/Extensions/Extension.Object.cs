using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dnc
{
    /// <summary>
    /// Extension methods for a <see cref="object"/>
    /// </summary>
    public static class ObjectExtensions
    {
        public static string ToHumanization<T>(this T obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            var props = typeof(T).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            if (props == null || !props.Any())
                return string.Empty;

            var propMaxLength = props.Max(p => p.Name.Length);
            var output = string.Empty;
            foreach (var prop in props)
            {
                var propValue = prop.GetValue(obj);
                output = $"{output}\r\n{prop.Name.PadLeft(propMaxLength, ' ')}:{propValue}";
            }
            return output;
        }
    }
}
