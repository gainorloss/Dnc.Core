using Dnc.Seedwork;
using System;

namespace Dnc.Biz.Comments
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
