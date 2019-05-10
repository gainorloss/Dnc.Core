using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Seedwork
{
    public interface IDomainEvent
        : IMessage
    { }

    public interface IDomainEvent<TAggregationRootId>
        : IDomainEvent
    {
        TAggregationRootId AggregationRootId { get; set; }
    }
}
