using Dnc.Seedwork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Biz.Admin
{
    public class SysDomain
        : Entity
    {
        public string DomainType { get; set; }
        public string Domain { get; set; }
    }
}
