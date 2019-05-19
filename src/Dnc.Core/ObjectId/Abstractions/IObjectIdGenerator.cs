using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.ObjectId
{
    /// <summary>
    /// Object id contains distributed unique id and son on.
    /// </summary>
    public interface IObjectIdGenerator
         : IPlugin
    {
        #region long id.
        /// <summary>
        /// Guid to long(19).
        /// </summary>
        /// <returns></returns>
        long IntGuid();

        /// <summary>
        /// snowflake id long(18).
        /// </summary>
        /// <param name="workerId"></param>
        /// <returns></returns>
        long IntSnowflakeId(int workerId = 0);
        #endregion

        #region string id.
        /// <summary>
        /// combined guid/timestamp seq(32).
        /// </summary>
        /// <returns></returns>
        string StringCombinedGuid();

        /// <summary>
        /// Guid,uuid(32).
        /// </summary>
        /// <returns></returns>
        string StringGuid(); 
        #endregion

    }
}
