using System.Threading.Tasks;
using Dnc.Events;

namespace Dnc.UnitTests
{
    public class TimeUpdatedEventHandler
        : DomainEventHandler<TimeUpdatedEvent>
    {
        public override Task HandleAsync(TimeUpdatedEvent @event)
        {
            var timestamp = @event.Timestamp;
            System.Console.WriteLine(timestamp);
            return Task.CompletedTask;
        }
    }
}
