﻿using System.Threading.Tasks;

namespace Dnc.Sender
{
    /// <summary>
    /// Constraint for alarmer.
    /// </summary>
    public interface IAlarmer
         : IPlugin
    {
        /// <summary>
        /// Alarm administrator using wechat.
        /// </summary>
        /// <param name="msg">message body.</param>
        /// <param name="title">message title.</param>
        /// <returns></returns>
        Task<bool> AlarmAdminUsingWechatAsync(string msg, string title);
    }
}
