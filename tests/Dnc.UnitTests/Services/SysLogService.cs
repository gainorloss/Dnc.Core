using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.UnitTests.Services
{
    public class SysLogService
        : ISysLogService
    {
        public Task AddLogAsync(string msg)
        {
            Console.WriteLine(msg);
            return Task.CompletedTask;
        }
    }
}
