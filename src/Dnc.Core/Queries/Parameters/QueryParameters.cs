using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Queries
{
    public class QueryParameters
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }
        public int PageCount { get; set; }
    }
}
