using Dnc.ObjectId;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Events
{
    public class DomainEvent
        : IEvent
    {
        public DomainEvent()
        {
            Id = Fx.Resolve<IObjectIdGenerator>().StringGuid();
            Timestamp = DateTime.UtcNow;
        }
        public string Id { get ; set ; }
        public int Version { get; set; }
        public DateTime Timestamp { get; set; }
        public int Seq { get; set; }
    }
}
