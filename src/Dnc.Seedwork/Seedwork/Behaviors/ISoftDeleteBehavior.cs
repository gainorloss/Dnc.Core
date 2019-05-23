using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Seedwork
{
    public interface ISoftDeleteBehavior
    {
        bool Deleted { get; set; }
        string DeleteRemark { get; set; }
    }
}
