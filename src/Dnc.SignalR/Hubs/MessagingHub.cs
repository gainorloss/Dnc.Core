using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Messager.Hubs
{
    public class MessagingHub
         : Hub<IMessager>
    {
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessageAsync()
        {
           await Clients.All.ReceiveMessageAsync("Dnc.Core");
        }
    }
}
