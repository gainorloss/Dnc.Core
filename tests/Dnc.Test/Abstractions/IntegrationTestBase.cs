using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net.Http;

namespace Dnc.Test.Abstractions
{
    public class IntegrationTestBase
    {
        public readonly HttpClient _httpClient;
        public IntegrationTestBase(Type startupType)
        {
            var webHostBuilder = WebHost
                .CreateDefaultBuilder()
                .UseStartup(startupType);

            _httpClient = new TestServer(webHostBuilder)
                .CreateClient();
        }
    }
}
