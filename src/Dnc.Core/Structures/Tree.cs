using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Structures
{
    public class Tree<T>
        : ITree<T>
        where T : class, new()
    {
        #region Ctor.
        public Tree()
        {
            Children = new List<ITree<T>>();
        } 
        #endregion

        #region Public props.
        public ITree<T> Parent { set; get; }

        public IEnumerable<ITree<T>> Children { set; get; }

        public int Id { set; get; }

        public int? ParentId { set; get; }

        public int Level { set; get; }

        public bool IsLeaf { set; get; }

        public string LinkUrl { set; get; } 
        #endregion
    }
}
