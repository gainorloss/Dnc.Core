using System;

namespace Dnc.Events
{
    internal class EventProcessedArgs
        : EventArgs
    {
        public EventProcessedArgs(IEvent @event)
        {
            @Event = @event;
        }
        public IEvent @Event { get; set; }
    }
}