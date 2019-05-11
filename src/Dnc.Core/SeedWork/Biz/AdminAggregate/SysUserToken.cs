using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Seedwork
{
    public class SysUserToken
        : Entity
    {
        public SysUserToken()
        {
            ExpireMS = DateTime.Now.AddDays(15);
            Token = Guid.NewGuid().ToString("N");
        }
        public SysUserToken(long userId)
            :this()
        {
            UserId = userId;
        }
        public long UserId { get; set; }
        public string Token { get; set; }
        public DateTime ExpireMS { get; set; }
    }
}
