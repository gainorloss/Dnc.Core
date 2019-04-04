using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Dnc.Testing
{

    public class BaseXunitTest<T>
        where T:class
    {
        #region Protected member.
        protected HttpClient HttpClient { get; }
        #endregion

        #region Ctor.
        public BaseXunitTest()
        {
            var server = new TestServer(WebHost.CreateDefaultBuilder()
                .UseStartup<T>());

            HttpClient = server.CreateClient();
        }
        #endregion
    }
}
