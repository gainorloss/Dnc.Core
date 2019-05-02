using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dnc.Structures
{
    /// <summary>
    /// Extension methods for creating a <see cref="ITree{T}"/> from a <see cref="IEnumerable{T}"/>.
    /// </summary>
    public static class TreeExtensions
    {
        public static IEnumerable<ITree<T>> CreateTree<T>(this IEnumerable<T> source)
            where T : class, ITree<T>, new()
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var items = new List<ITree<T>>();

            var nodes = source
                .Where(i => i.Level == 1)
                .ToList();

            foreach (var node in nodes)
            {
                var item = new Tree<T>()
                {
                    Id = node.Id,
                    ParentId = node.ParentId,
                    IsLeaf = node.IsLeaf,
                    Level = node.Level,
                    LinkUrl = node.LinkUrl
                };

                item.Children = CreateChildren(source, node, item);
                items.Add(item);
            }
            return items;
        }

        private static IEnumerable<ITree<T>> CreateChildren<T>(IEnumerable<T> source, T node, Tree<T> item) where T : class, ITree, new()
        {
            var items = new List<ITree<T>>();
            foreach (var child in source
                .Where(i => i.ParentId == node.Id)
                .ToList())
            {
                var son = new Tree<T>()
                {
                    Id = node.Id,
                    ParentId = node.ParentId,
                    IsLeaf = node.IsLeaf,
                    Level = node.Level,
                    LinkUrl = node.LinkUrl
                };
                son.Children = CreateChildren(source, child, son);
                items.Add(son);
            }
            return items;
        }
    }
}
