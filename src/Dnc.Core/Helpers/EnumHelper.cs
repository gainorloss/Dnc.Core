using Dnc.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Dnc
{
    /// <summary>
    /// Enum helper.
    /// </summary>

    public class EnumHelper<T>
   where T : struct
    {
        public static List<EnumValueModel> models = new List<EnumValueModel>();

        static EnumHelper()
        {
            var type = typeof(T);
            if (!type.IsEnum)
            {
                throw new Exception("Type have to be enum.");
            }

            var values = type.GetEnumValues();
            if (values != null && values.Length > 0)
            {
                foreach (var val in values)
                {
                    var iVal = (int)val;

                    var name = type.GetEnumName(val);
                    var fieldInfo = type.GetField(name);

                    var annotation = name;
                    var attrs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if (attrs != null && attrs.Any())
                    {
                        var attr = attrs.FirstOrDefault() as DescriptionAttribute;
                        annotation = attr.Description ?? name;
                    }
                    var model = new EnumValueModel(name, iVal, annotation);
                    models.Add(model);
                }
            }
        }


        public static List<EnumValueModel> GetEnumModels()
        {
            return models;
        }


        public static EnumValueModel GetEnumModelByName(string name)
        {
            return models.SingleOrDefault(m => m.Name.Equals(name));
        }
    }
}
