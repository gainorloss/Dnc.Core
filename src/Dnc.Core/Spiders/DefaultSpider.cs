using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using Dnc.Extensions;
using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dnc.Spiders
{
    public class DefaultSpider
        : ISpider
    {
        #region Private member.
        private readonly IHtmlParser _htmlParser;
        private readonly IHtmlDownloader _htmlDownloader;
        private readonly IUrlManager _urlManager;
        private readonly IPipelineProcessor _processor;
        #endregion

        #region Default ctor.
        public DefaultSpider(IHtmlParser htmlParser,
           IHtmlDownloader htmlDownloader,
           IUrlManager urlManager,
           IPipelineProcessor processor)
        {
            _htmlParser = htmlParser;
            _htmlDownloader = htmlDownloader;
            _urlManager = urlManager;
            _processor = processor;
        }
        #endregion

        public async Task StartAsync(params string[] urls)
        {
            if (urls == null)
                throw new ArgumentNullException(nameof(urls));

            _urlManager.AddNewUrls(urls);

            while (_urlManager.HasNewUrl())
            {
                var url = _urlManager.GetNewUrl();

                var html = await _htmlDownloader.DownloadHtmlContentAsync(url);

                await _processor.ProcessItemAsync(url,html);

                var eles = await _htmlParser.GetElementsAsync(html, "a");

                if (eles != null && eles.Length > 0)
                {
                    eles.Parallel(1000,selected=>
                    {
                        var newUrls = new List<string>();
                        foreach (var ele in selected)
                        {
                            var newUrl = ele.GetAttribute("href");
                            newUrls.Add(newUrl);
                        }
                        _urlManager.AddNewUrls(newUrls.ToArray());
                    });
                }
            }
        }
    }
}
