using Dnc.SeedWork;
using GenFu;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.SeedWork
{
    public class GenFuMockRepository
        : IMockRepository
    {
        public IEnumerable<T> CreateMultiple<T>() where T : class, new() => A.ListOf<T>();

        public T Create<T>() where T : class, new() => A.New<T>();
    }
}
