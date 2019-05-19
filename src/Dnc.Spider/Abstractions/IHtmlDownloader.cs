using System;
using System.Threading.Tasks;

namespace Dnc.Spider
{
    /// <summary>
    /// Interface for html downloader.
    /// </summary>
    public interface IHtmlDownloader
    {
        Task<string> DownloadHtmlContentAsync(string url,string agent = null);
    }
}
