using Dnc.Events;

namespace Dnc.UnitTests
{
    public class VersionSetEvent
        : DomainEvent
    {
        public VersionSetEvent()
        {
            Version = 1;
        }
    }
}
