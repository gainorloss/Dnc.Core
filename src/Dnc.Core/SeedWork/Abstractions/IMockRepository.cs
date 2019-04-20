using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.SeedWork
{
    public interface IMockRepository
    {
        T Create<T>()
            where T : class, new();

        IEnumerable<T> CreateMultiple<T>() 
            where T : class, new();
    }
}
