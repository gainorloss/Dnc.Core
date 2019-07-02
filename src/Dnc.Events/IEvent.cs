using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Events
{
    public interface IEvent
    {
        string Id { get;}
        string Payload { get;  }
        int Version { get;  }
        DateTime OccurredOn { get; }
        int Seq { get; }
    }
}
