using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Seedwork
{
    /// <summary>
    /// Design for comment.
    /// </summary>
    public class Comment
        :Entity
    {
        /// <summary>
        /// Commment which news?
        /// </summary>
        public int NewsId { get; set; }

        /// <summary>
        /// Reply for who?
        /// </summary>
        public int? ParentId { get; set; }

        public DateTime Date { get; set; }

        /// <summary>
        /// Content of comment.
        /// </summary>
        public string Content { get; set; }
    }
}
