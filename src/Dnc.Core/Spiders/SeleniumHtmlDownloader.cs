using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PuppeteerSharp;

namespace Dnc.Spiders
{
    public class SeleniumHtmlDownloader
         : IHtmlDownloader
    {
        public Task<string> DownloadHtmlContentAsync(string url, Func<Page, Task> beforeGetContentHandler = null, string agent = null)
        {
            throw new NotImplementedException();
        }
    }
}
