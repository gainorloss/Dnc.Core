using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Rpc
{
    public class GrpcClient
         : IRpcClient
    {
        public TClient GetClient<TClient>(string host,
            int port,
            Func<Channel, TClient> buildClientFunc)
            where TClient : ClientBase<TClient>
        {
            var channel = new Channel(host, port, ChannelCredentials.Insecure);

            return buildClientFunc.Invoke(channel);

        }
    }
}
