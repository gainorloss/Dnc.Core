using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.SeedWork
{
    public interface IMessage
    {
        string UniqueId { get; set; }
        int Version { get; set; }
        DateTime Timestamp { get; set; }
        int Seq { get; set; }
    }
}
