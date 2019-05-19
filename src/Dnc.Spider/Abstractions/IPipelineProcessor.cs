using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Spider
{
    /// <summary>
    /// Constraint for html outputer.
    /// </summary>
    public interface IPipelineProcessor
    {
        Task ProcessItemAsync(string url,string html);
    }
}
