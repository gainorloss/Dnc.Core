using System;
using System.Threading.Tasks;

namespace Dnc.Spider.Selenium
{
    public interface IHtmlDownloader
        :IPlugin
    {
        Task<string> DownloadHtmlContentAsync(string url, string proxy = null);
    }
}
