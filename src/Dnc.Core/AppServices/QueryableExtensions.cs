using Dnc.AppServices;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Dnc
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> SortBy<T>(this IQueryable<T> source, string orderBy, IPropertyMapping mapping)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (string.IsNullOrWhiteSpace(orderBy))
                return source;

            if (mapping == null)
                throw new ArgumentNullException(nameof(mapping));

            var mappingDictionary = mapping.MappingDictionary;
            if (mappingDictionary == null)
                throw new ArgumentNullException(nameof(mapping));

            var orderByAfterSplit = orderBy.Split(',');

            foreach (var orderByClause in orderByAfterSplit)
            {
                var trimmedOrderByClause = orderByClause.Trim();
                var orderByDesending = trimmedOrderByClause.EndsWith(" desc");
                var indexOfFirstSpace = trimmedOrderByClause.IndexOf(" ", StringComparison.Ordinal);
                var propertyName = indexOfFirstSpace == -1 ? trimmedOrderByClause : trimmedOrderByClause.Remove(indexOfFirstSpace);

                if (string.IsNullOrWhiteSpace(propertyName))
                    continue;

                if (!mappingDictionary.TryGetValue(propertyName, out var mappedProperties))
                    throw new Exception($"Property mapping for {propertyName} is missing.");

                if (mappedProperties == null)
                    throw new ArgumentNullException(nameof(mappedProperties));

                foreach (var mappedProperty in mappedProperties)
                {
                    if (mappedProperty.Revert)
                        orderByDesending = !orderByDesending;

                    var orderByDesendingStr = orderByDesending ? "descending" : "ascending";
                    source = source.OrderBy($"{propertyName} {orderByDesendingStr}");
                }
            }
            return source;
        }
    }
}
