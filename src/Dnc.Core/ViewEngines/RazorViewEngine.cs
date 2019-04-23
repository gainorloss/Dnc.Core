using System;
using System.Threading.Tasks;

namespace Dnc.ViewEngines
{
    public class RazorViewEngine
        : IViewEngine
    {
        public Task<string> ParseAsync(string template, object data)
        {
            throw new NotImplementedException();
        }
    }
}
