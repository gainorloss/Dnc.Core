using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Seedwork
{
    public interface ISoftDeleteBehavior
    {
        bool Deleted { get; set; }
        DateTime DeletedAt { get; set; }
        long DeletorId { get; set; }
        string Deletor { get; set; }
    }
}
