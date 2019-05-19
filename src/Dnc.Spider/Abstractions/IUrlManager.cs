using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Spider
{
    /// <summary>
    /// Constraint for url manager.
    /// </summary>
    public interface IUrlManager
    {
        void AddNewUrls(params string[] urls);

        bool HasNewUrl();

        string GetNewUrl();
    }
}
