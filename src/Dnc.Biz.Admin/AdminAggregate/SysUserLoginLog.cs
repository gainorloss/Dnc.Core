using Dnc.Seedwork;
using System;

namespace Dnc.Biz.Admin
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
