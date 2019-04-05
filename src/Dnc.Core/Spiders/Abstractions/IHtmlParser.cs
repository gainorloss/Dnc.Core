using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Spiders
{
    public interface IHtmlParser
    {

        Task<IHtmlCollection<IElement>> GetElementsAsync(string html, string selectors);

        Task<IElement> GetElementAsync(string html, string selector);
    }
}
