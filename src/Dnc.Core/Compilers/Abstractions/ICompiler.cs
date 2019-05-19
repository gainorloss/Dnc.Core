using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Compilers
{
    /// <summary>
    /// Compiler.
    /// </summary>
    public interface ICompiler
        :IPlugin
    {
        Task<T> RunAsync<T>(string script,
            object arg = null,
            string nameSpace = null,
            params Assembly[] references);
    }
}
