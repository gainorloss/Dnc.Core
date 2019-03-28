using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Structure
{
    /// <summary>
    /// Structure tree constraint.
    /// </summary>
    public interface ITree
    {
        int Id { get; }

        int ParentId { get; }

        int Level { get; }

        bool IsLeaf { get; }

        string LinkUrl { get; }
    }


    /// <summary>
    /// Structure tree constraint (generic) <see cref="ITree"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITree<T>
        : ITree
    {
        T Parent { get; }

        IEnumerable<T> Children { get; }
    }
}
