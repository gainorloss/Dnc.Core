using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Seedwork
{
    public interface IMockRepository
        :IPlugin
    {
        T Create<T>()
            where T : class, new();

        IEnumerable<T> CreateMultiple<T>() 
            where T : class, new();
    }
}
