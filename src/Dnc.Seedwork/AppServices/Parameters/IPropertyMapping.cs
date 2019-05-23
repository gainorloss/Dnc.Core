using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.AppServices
{
    public interface IPropertyMapping
    {
        Dictionary<string, List<MappedProperty>> MappingDictionary { get; }
    }
}
