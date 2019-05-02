using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Dnc.AspNetCore;

namespace Dnc.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseDncCore(ctor =>
            {
                ctor.UseRedis(opt =>
                {
                    opt.Host = "140.143.88.100";
                    opt.Password = "p@ssw0rd";
                    opt.Port = 6379;
                    opt.InstanceName = "Dnc.API";
                });
            })
                .UseStartup<Startup>();
    }
}
