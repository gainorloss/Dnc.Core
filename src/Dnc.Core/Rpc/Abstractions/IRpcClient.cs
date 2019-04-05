using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Rpc
{
    public interface IRpcClient
    {
        ClientBase<TClient> GetClient<TClient>(string host,
            int port,
            Func<Channel, ClientBase<TClient>> buildClientFunc)
            where TClient : ClientBase<TClient>;
    }
}
