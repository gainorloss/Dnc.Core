using AngleSharp.Dom;
using Dnc.Spiders;
using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Spiders
{
    /// <summary>
    /// Interface for html downloader.
    /// </summary>
    public interface IHtmlDownloader
    {
        Task<string> DownloadHtmlContentAsync(string url, Func<Page, Task> beforeGetContentHandler = null, string agent = null);
    }
}
