using PuppeteerSharp;
using System;
using System.Threading.Tasks;

namespace Dnc.Spider
{
    /// <summary>
    /// Interface for html downloader.
    /// </summary>
    public interface IHtmlDownloader
        :IPlugin
    {
        Task<string> DownloadHtmlContentAsync(string url, Func<Page, Task> beforeGetContentHandler = null, string proxy = null);
    }
}
