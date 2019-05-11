using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Seedwork
{
    /// <summary>
    /// Interface for aggregation root.
    /// </summary>
    public interface IAggregationRoot
        : IMessage
    { }

    public interface IAggregationRoot<TAggregationRootId>
      : IAggregationRoot
    {
        TAggregationRootId AggregationRootId { get; set; }
    }
}
