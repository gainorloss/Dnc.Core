﻿using System;

namespace Dnc.Events
{
    public interface IEventSubscriber:IDisposable
    {
        void Subscribe<TEvent,TEventHandler>()
            where TEvent:IEvent
            where TEventHandler:IEventHandler<TEvent>;
    }
}
