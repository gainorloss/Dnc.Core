using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Structures
{
    public struct Work
    {
        public object State;
        public Action<object> Callback;
    }
}