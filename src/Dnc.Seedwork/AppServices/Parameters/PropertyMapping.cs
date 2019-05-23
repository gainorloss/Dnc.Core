using Dnc.Seedwork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.AppServices
{
    public abstract class PropertyMapping<TSource, TDestination> 
        :IPropertyMapping
        where TDestination : Entity
    {
        public Dictionary<string, List<MappedProperty>> MappingDictionary { get; }
        public PropertyMapping(Dictionary<string, List<MappedProperty>> propertyMappingDic)
        {
            MappingDictionary = propertyMappingDic;
            MappingDictionary.Add(nameof(Entity.Id), new List<MappedProperty>()
            {
                new MappedProperty(nameof(Entity.Id))
            });
        }
    }
}
