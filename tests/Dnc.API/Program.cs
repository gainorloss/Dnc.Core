using Dnc.AspNetCore;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

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
            .UseCore(ctor =>
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
