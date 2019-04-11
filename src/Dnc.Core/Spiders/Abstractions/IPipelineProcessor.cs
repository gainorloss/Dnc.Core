using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Spiders
{
    /// <summary>
    /// Constraint for html outputer.
    /// </summary>
    public interface IPipelineProcessor
    {
        void ProcessItem<T>(T item)
            where T:class,ISpiderItem,new();
    }
}
