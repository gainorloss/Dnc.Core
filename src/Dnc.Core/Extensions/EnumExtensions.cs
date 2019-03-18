using Dnc.Helpers;
using Dnc.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Extensions
{
    /// <summary>
    /// Extension methods for enum.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Get descrition attribute text.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetAnnotation<T>(this T t)
            where T : struct
        {
            var model = EnumHelper<T>.GetEnumModelByName(t.ToString());
            return model.Annotation;
        }


        /// <summary>
        /// Get enum all values content.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<EnumValueModel> GetEnumValueModels<T>(this T t)
            where T : struct
        {
            var models = EnumHelper<T>.GetEnumModels();
            return models;
        }


        /// <summary>
        /// Get enum value content by name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public static EnumValueModel GetEnumValueModelByName<T>(this T t)
            where T : struct
        {
            return EnumHelper<T>.GetEnumModelByName(t.ToString());
        }
    }

}
