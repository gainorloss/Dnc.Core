using Dnc.Events;
using System;

namespace Dnc.UnitTests
{
    [Serializable]
    public class VersionSetEvent
        : DomainEvent
    {
        public VersionSetEvent()
        {
            Version = 1;
        }
    }
}
