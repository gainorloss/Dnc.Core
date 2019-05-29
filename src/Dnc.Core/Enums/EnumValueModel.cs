using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc
{
    /// <summary>
    /// Enum value model.
    /// </summary>
    public class EnumValueModel
    {
        public EnumValueModel(string name,
            object val,
            string annotation)
        {
            Name = name;
            Value = val;
            Annotation = annotation;
        }
        public string Name { get; set; }
        public object Value { get; set; }
        public string Annotation { get; set; }
    }

}
