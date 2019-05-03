using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.SeedWork
{
    public interface IMessageHandler
    { }
    public interface IMessageHandler<TMessage>
        : IMessageHandler
        where TMessage : IMessage
    {
        void Handle(TMessage message);

        Task HandleAsync(TMessage message);
    }
}
