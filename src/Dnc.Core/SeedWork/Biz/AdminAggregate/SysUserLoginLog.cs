using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Seedwork
{
    public class SysUserLoginLog
        :Entity
    {
        public int UserId { get; set; }
        public DateTime LoginTime { get; set; }
        public string IPAddress { get; set; }
    }
}
