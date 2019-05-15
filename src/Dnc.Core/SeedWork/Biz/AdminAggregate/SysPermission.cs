using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Seedwork
{
    public class SysPermission
        : Entity
    {
        public long RoleId { get; set; }
        public long ResourceId { get; set; }
    }
}
