using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Seedwork
{
    public class SysRole
        : Entity
    {
        public string Name { get; set; }

        public string ParentId { get; set; }
    }
}
