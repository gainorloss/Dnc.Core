using System;

namespace Dnc.Events
{
    [Serializable]
    public class DomainEvent
        : IEvent
    {
        protected DomainEvent()
        {
            Id = Guid.NewGuid().ToString("N");
            OccurredOn = DateTime.UtcNow;
        }

        public string Id { get; protected set; }
        public string Payload { get; protected set; }
        public int Version { get; protected set; }
        public DateTime OccurredOn { get; protected set; }
        public int Seq { get; protected set; }
    }
}
