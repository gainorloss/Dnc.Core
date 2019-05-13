using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using System.Text;

namespace Dnc.Core.AppServices
{
    public static class AppServicesExtensions
    {
        /// <summary>
        /// List data shaped.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public static IEnumerable<ExpandoObject> ToDynamic<TSource>(this IEnumerable<TSource> source, string fields = null)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var expandoObjectList = new List<ExpandoObject>();
            var propertyInfoList = new List<PropertyInfo>();

            if (string.IsNullOrEmpty(fields))
            {
                var props = typeof(TSource).GetProperties(BindingFlags.Instance | BindingFlags.PutDispProperty);
                propertyInfoList.AddRange(props);
            }
            else
            {
                var fieldsAfterSplit = fields.Split(',');
                foreach (var field in fieldsAfterSplit)
                {
                    if (string.IsNullOrEmpty(field))
                        continue;
                    var prop = typeof(TSource).GetProperty(field, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
                    if (prop == null)
                        throw new Exception($"{field} is not existed in {typeof(TSource).FullName}.");
                    propertyInfoList.Add(prop);
                }
            }

            foreach (var obj in source)
            {
                var expandoObject = new ExpandoObject();
                foreach (var prop in propertyInfoList)
                {
                    var val = prop.GetValue(obj);
                    ((IDictionary<string, object>)expandoObject).Add(prop.Name, val);
                }
                expandoObjectList.Add(expandoObject);
            }
            return expandoObjectList;
        }

        /// <summary>
        /// Object data shaped.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public static ExpandoObject ToDynamic<TSource>(this TSource source, string fields = null)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var expandoObject = new ExpandoObject();

            if (string.IsNullOrEmpty(fields))
            {
                var props = typeof(TSource).GetProperties(BindingFlags.Instance | BindingFlags.Public);

                foreach (var prop in props)
                {
                    var val = prop.GetValue(source);
                    ((IDictionary<string, object>)expandoObject).Add(prop.Name,val);
                }
                return expandoObject;
            }
            else
            {
                var fieldsAfterSplit = fields.Split(',');
                foreach (var field in fieldsAfterSplit)
                {
                    if (string.IsNullOrEmpty(field))
                        continue;
                    var prop = typeof(TSource).GetProperty(field, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
                    if (prop == null)
                        throw new Exception($"{field} is not existed in {typeof(TSource).FullName}.");
                    var val = prop.GetValue(source);
                    ((IDictionary<string, object>)expandoObject).Add(prop.Name, val);
                }
            }
            return expandoObject;
        }
    }
}
