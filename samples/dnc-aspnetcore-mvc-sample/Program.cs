using Dnc.AspNetCore;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
namespace dnc_aspnetcore_mvc_sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseCore()
                .UseStartup<Startup>();
    }
}
