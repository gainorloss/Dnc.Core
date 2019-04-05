using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Rpc
{
    public interface IRpcServer
    {
        Server GetServer(string host,
            int port,
            Func<ServerServiceDefinition> buildServiceDefinitionFunc);
    }
}
