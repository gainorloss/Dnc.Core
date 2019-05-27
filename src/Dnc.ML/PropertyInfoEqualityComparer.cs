using System.Collections.Generic;
using System.Reflection;

namespace Dnc.ML
{
    internal class PropertyInfoEqualityComparer : IEqualityComparer<PropertyInfo>
    {
        public bool Equals(PropertyInfo x, PropertyInfo y) => x.Name.Equals(y.Name);

        public int GetHashCode(PropertyInfo obj) => obj.Name.GetHashCode();
    }
}