using Dnc.Seedwork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.AppServices
{
    public class PropertyMapping<TSource, TDestination>
        where TDestination : Entity
    {
        public Dictionary<string, List<MappedProperty>> PropertyMappingDic { get; }
        public PropertyMapping(Dictionary<string, List<MappedProperty>> propertyMappingDic)
        {
            PropertyMappingDic = propertyMappingDic;
            PropertyMappingDic.Add(nameof(Entity.Id), new List<MappedProperty>()
            {
                new MappedProperty(nameof(Entity.Id))
            });
        }
    }
}
