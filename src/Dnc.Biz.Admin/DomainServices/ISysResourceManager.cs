using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;

namespace Dnc.Biz.Admin
{
    public interface ISysResourceManager
    {
        IEnumerable<SysResource> GetAll<TStartup>()
            where TStartup : IStartup;
    }
}
