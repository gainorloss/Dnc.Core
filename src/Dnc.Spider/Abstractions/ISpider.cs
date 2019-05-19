using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Spider
{
    /// <summary>
    /// The interface of spider.
    /// </summary>
    public interface ISpider
    {
        Task StartAsync(params string[] urls);
    }
}
