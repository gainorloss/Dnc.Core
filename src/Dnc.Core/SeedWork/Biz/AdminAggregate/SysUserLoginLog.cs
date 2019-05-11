using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Seedwork
{
    public class SysUserLoginLog
        : Entity
    {
        public SysUserLoginLog()
        {
            LoginTime = DateTime.Now;
        }
        public SysUserLoginLog(long userId,string msg,string ip=null)
            :this()
        {
            UserId = userId;
            Message = msg;
            IPAddress = ip;
        }
        public long UserId { get; set; }
        public DateTime LoginTime { get; set; }
        public string IPAddress { get; set; }
        public string Message { get; set; }
    }
}
