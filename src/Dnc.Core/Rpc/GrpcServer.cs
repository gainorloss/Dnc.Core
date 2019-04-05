using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Rpc
{
    public class GrpcServer
         : IRpcServer
    {
        private Server server = null;
        public Server GetServer(string host,
            int port,
            Func<ServerServiceDefinition> buildServiceDefinitionFunc)
        {
            var server = new Server()
            {
                Services = { buildServiceDefinitionFunc.Invoke() },
                Ports = { new ServerPort(host, port, ServerCredentials.Insecure) }
            };
            return server;
        }

        public void Start(string host,
            int port,
             Func<ServerServiceDefinition> buildServiceDefinitionFunc)
        {
            (server ?? (server = GetServer(host, port, buildServiceDefinitionFunc)))
                .Start();
        }
    }
}
