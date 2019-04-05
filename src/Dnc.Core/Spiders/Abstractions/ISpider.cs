using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Spiders
{
    /// <summary>
    /// The interface of spider.
    /// </summary>
    public interface ISpider
    {
        Task<IEnumerable<T>> GetItemsAsync<T>(string url,
            string selectors,
            Func<IElement, T> buildItemFunc)
            where T : class, ISpiderItem, new();

        Task<T> GetItemAsync<T>(string url,
           string selector,
           Func<IElement, T> buildItemFunc)
            where T : class, ISpiderItem, new();
    }
}
