using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Rpc
{
    public interface IRPCServer
    {
        Server GetServer(string host,
            int port,
            Func<ServerServiceDefinition> buildServiceDefinitionFunc);
    }
}
