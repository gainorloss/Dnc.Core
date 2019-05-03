using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.SeedWork
{
    public class AggregationRoot
        : AbstractMessage, IAggregationRoot<string>
    {
        public AggregationRoot()
        {
            AggregationRootId = Guid.NewGuid().ToString("N");
        }
        public string AggregationRootId { get; set; }
    }
}
