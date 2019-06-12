using Dnc.Serializers;
using System;

namespace Dnc.Events
{
    [Serializable]
    public class DomainEvent
        : IEvent
    {
        public DomainEvent()
        {
            Id = Guid.NewGuid().ToString("N");
            Timestamp = DateTime.UtcNow;
        }
        public string Id { get; set; }
        public string Payload { get; set; }
        public int Version { get; set; }
        public DateTime Timestamp { get; set; }
        public int Seq { get; set; }
    }
}
