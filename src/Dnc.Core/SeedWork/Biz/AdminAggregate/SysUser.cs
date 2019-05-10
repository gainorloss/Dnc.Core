using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Seedwork
{
    public class SysUser
        : Entity
    {
        public string UName { get; set; }
        public string Pwd { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Avatar { get; set; }
        public DateTime? LastSignInTime { get; set; }
        public int LoginErrNums { get; set; }
        public string LastLoginIP { get; set; }
        public DateTime? LastSignOutTime { get; set; }
    }
}
