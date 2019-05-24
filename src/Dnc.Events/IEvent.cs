using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Events
{
    public interface IEvent
    {
        string Id { get; set; }
        string Payload { get; set; }
        int Version { get; set; }
        DateTime Timestamp { get; set; }
        int Seq { get; set; }
    }
}
