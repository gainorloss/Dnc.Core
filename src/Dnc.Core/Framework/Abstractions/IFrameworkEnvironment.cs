using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc
{
    public interface IFrameworkEnvironment
    {
        bool IsDevelopment { get; set; }
        string Environment { get; }
    }
}
