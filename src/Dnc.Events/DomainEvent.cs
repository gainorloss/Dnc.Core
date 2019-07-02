using System;

namespace Dnc.Events
{
    [Serializable]
    public class DomainEvent
        : IEvent
    {
        private DomainEvent()
        {
            Id = Guid.NewGuid().ToString("N");
            OccurredOn = DateTime.UtcNow;
        }

        public string Id { get; private set; }
        public string Payload { get; private set; }
        public int Version { get; private set; }
        public DateTime OccurredOn { get; private set; }
        public int Seq { get; private set; }
    }
}
