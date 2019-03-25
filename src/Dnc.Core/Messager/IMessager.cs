using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Messager
{
    /// <summary>
    /// The constraint of instant messager .
    /// </summary>
    public interface IMessager
    {
        Task ReceiveMessageAsync(string message);
    }
}
