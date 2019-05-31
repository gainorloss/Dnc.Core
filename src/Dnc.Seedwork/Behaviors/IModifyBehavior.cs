using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Seedwork
{
    public interface IModifyBehavior
    {
        DateTime? ModifiedAt { get; set; }
        long ModifierId { get; set; }
        string Modifier { get; set; }
    }
}
