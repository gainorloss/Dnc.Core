using Dnc.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.UnitTests
{
    public class VersionSetEventHandler
        : DomainEventHandler<VersionSetEvent>
    {
        public VersionSetEventHandler(IEventStore eventStore)
            : base(eventStore)
        { }

        protected override Task HandleAsync(VersionSetEvent @event)
        {
            var version = @event.Version;
            return Task.FromResult(version);
        }
    }
}
