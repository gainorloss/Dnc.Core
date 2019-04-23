using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.ViewEngines
{
    /// <summary>
    /// Constraint for view engine;
    /// </summary>
    public interface IViewEngine
    {
        Task<string> ParseAsync(string template,object data);
    }
}
