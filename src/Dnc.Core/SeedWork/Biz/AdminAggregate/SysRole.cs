using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.SeedWork
{
    public class SysRole
        : Entity
    {
        public string Name { get; set; }

        public string ParentId { get; set; }
    }
}
