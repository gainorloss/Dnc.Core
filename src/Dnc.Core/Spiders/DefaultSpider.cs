using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Spiders
{
    public class DefaultSpider
        : ISpider
    {
        private readonly IHtmlParser _htmlParser;
        private readonly IHtmlDownloader _htmlDownloader;
        private readonly IUrlManager _urlManager;
        public DefaultSpider(IHtmlParser htmlParser,
            IHtmlDownloader htmlDownloader, 
            IUrlManager urlManager)
        {
            _htmlParser = htmlParser;
            _htmlDownloader = htmlDownloader;
            _urlManager = urlManager;
        }
    }
}
