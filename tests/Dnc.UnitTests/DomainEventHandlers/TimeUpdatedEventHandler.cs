using System.Threading.Tasks;
using Dnc.Aspects;
using Dnc.Events;

namespace Dnc.UnitTests
{
    public class TimeUpdatedEventHandler
        : DomainEventHandler<TimeUpdatedEvent>
    {
        public TimeUpdatedEventHandler(IEventStore eventStore)
            : base(eventStore)
        { }

        protected override Task HandleAsync(TimeUpdatedEvent @event)
        {
            var timestamp = @event.Timestamp;
            System.Console.WriteLine(timestamp);
            return Task.CompletedTask;
        }
    }
}
