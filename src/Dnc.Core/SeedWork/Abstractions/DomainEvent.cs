using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Seedwork
{
    public class DomainEvent
        : AbstractMessage, IDomainEvent<string>
    {
        public DomainEvent()
        {
            AggregationRootId = Guid.NewGuid().ToString("N");
        }
        public string AggregationRootId { get; set; }
    }
}
