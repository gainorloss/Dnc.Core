using Ocelot.Configuration.File;
using Ocelot.Configuration.Repository;
using Ocelot.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Micro.Gateways
{
    public class MySqlFileConfigurationRepository
        : IFileConfigurationRepository
    {
        public Task<Response<FileConfiguration>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Response> Set(FileConfiguration fileConfiguration)
        {
            throw new NotImplementedException();
        }
    }
}
