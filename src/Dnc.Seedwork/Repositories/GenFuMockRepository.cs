using GenFu;
using System.Collections.Generic;

namespace Dnc.Seedwork
{
    public class GenFuMockRepository
        : IMockRepository
    {
        public IEnumerable<T> CreateMultiple<T>() where T : class, new() => A.ListOf<T>();

        public T Create<T>() where T : class, new() => A.New<T>();
    }
}
