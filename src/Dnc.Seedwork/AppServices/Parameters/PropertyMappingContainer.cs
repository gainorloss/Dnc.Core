using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dnc.Seedwork;

namespace Dnc.AppServices
{
    public class PropertyMappingContainer
        : IPropertyMappingContainer
    {
        protected internal readonly IList<IPropertyMapping> PropertyMappings = new List<IPropertyMapping>();
        public void Register<T>() where T : IPropertyMapping, new()
        {
            if (!PropertyMappings.Any(p => p.GetType() == typeof(T)))
                PropertyMappings.Add(new T());
        }

        public IPropertyMapping Resolve<TSource, TDestination>() where TDestination : Entity
        {
            var matchingPropertyMappings = PropertyMappings.OfType<PropertyMapping<TSource, TDestination>>();
            if (matchingPropertyMappings.Count() == 1)
                return matchingPropertyMappings.First();
            throw new Exception($"Cannot find any property mapping for <{typeof(TSource)},{typeof(TDestination)}>");
        }

        public bool ValidatePropertyMappingExistsFor<TSource, TDestination>(string fields) where TDestination : Entity
        {
            var propertyMapping = Resolve<TSource, TDestination>();

            if (string.IsNullOrWhiteSpace(fields))
                return true;

            var fieldsAfterSplit = fields.Split(',');
            foreach (var fieldAfterSplit in fieldsAfterSplit)
            {
                if (string.IsNullOrWhiteSpace(fieldAfterSplit))
                    continue;
                var trimmedField = fieldAfterSplit.Trim();
                var indexOfFirstSpace = trimmedField.IndexOf(" ", StringComparison.Ordinal);

                var propertyName = indexOfFirstSpace == -1 ? trimmedField : trimmedField.Remove(indexOfFirstSpace);
                if (propertyMapping.MappingDictionary.ContainsKey(propertyName))
                    return false;
            }
            return true;
        }
    }
}

