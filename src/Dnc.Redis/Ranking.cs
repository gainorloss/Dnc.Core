using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Redis
{
    public class Ranking<T>
    {
        public string Title { get; set; }
        public long Score { get; set; }
        public T Ranked { get; set; }
    }
}
