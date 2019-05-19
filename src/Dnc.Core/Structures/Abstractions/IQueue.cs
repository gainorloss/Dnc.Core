using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Structures
{
    public interface IQueue
        :IPlugin
    {
        void Enqueue(Action<object> callback,object state);

        void DoWork();
    }
}
