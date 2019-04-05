using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;

namespace Dnc.Spiders
{
    public class AngleSharpHtmlParser
        : IHtmlParser
    {
        #region Methods for getting html elements.
        public async Task<IElement> GetElementAsync(string html, string selector)
        {
            var doc = await GetHtmlDocumentUsingAngleSharpAsync(html);

            return doc.QuerySelector(selector);
        }


        public async Task<IHtmlCollection<IElement>> GetElementsAsync(string html, string selectors)
        {
            var doc = await GetHtmlDocumentUsingAngleSharpAsync(html);

            return doc.QuerySelectorAll(selectors);
        } 
        #endregion

        #region AngleSharp helper.
        private async Task<IHtmlDocument> GetHtmlDocumentUsingAngleSharpAsync(string html)
        {
            var parser = new HtmlParser();
            var doc = await parser.ParseDocumentAsync(html);
            return doc;
        }
        #endregion
    }
}
