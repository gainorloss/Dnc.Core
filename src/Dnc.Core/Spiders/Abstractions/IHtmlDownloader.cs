using AngleSharp.Dom;
using Dnc.Spiders;
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
        Task<string> DownloadHtmlContentAsync(string url);
    }
}
