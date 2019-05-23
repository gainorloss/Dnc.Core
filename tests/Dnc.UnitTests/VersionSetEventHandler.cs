using Dnc.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.UnitTests
{
    public class VersionSetEventHandler
        : IEventHandler<VersionSetEvent>
    {
        public bool CanHandle<TEvent>(TEvent @event) where TEvent : IEvent=>true;

        public Task HandleAsync(VersionSetEvent @event)
        {
            var version = @event.Version;
            return Task.FromResult(version);
        }

        public Task HandleAsync<TEvent>(TEvent @event) where TEvent : IEvent
        {
            var version = @event.Version;
            return Task.FromResult(version);
        }
    }
}
