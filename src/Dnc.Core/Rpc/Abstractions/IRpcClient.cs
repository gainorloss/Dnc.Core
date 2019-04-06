using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Rpc
{
    public interface IRpcClient
    {
        TClient GetClient<TClient>(string host,
            int port,
            Func<Channel, TClient> buildClientFunc)
            where TClient : ClientBase<TClient>;
    }
}
