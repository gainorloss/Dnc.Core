using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Seedwork
{
    public interface ISysResourceManager
    {
        IEnumerable<SysResource> GetAll<TStartup>()
            where TStartup : IStartup;
    }
}
