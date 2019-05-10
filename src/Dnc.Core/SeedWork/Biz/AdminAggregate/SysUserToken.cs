using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Seedwork
{
    public class SysUserToken
        : Entity
    {
        public int UserId { get; set; }
        public string Token { get; set; }
        public int ExpireMS { get; set; }
    }
}
