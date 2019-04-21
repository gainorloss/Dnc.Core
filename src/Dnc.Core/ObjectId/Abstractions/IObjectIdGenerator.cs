using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.ObjectId
{
    /// <summary>
    /// Object id contains distributed unique id and son on.
    /// </summary>
    public interface IObjectIdGenerator
    {
        /// <summary>
        /// Guid,uuid(32).
        /// </summary>
        /// <returns></returns>
        string Uuid();

        /// <summary>
        /// Guid to long(19).
        /// </summary>
        /// <returns></returns>
        long IntGuid();

        /// <summary>
        /// combined guid/timestamp seq(32).
        /// </summary>
        /// <returns></returns>
        string CombinedGuid();
    }
}
