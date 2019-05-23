using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Seedwork
{
    public interface IModifyBehavior
    {
        DateTime? LastModifyTime { get; set; }
        string LastModifyRemark { get; set; }
    }
}
