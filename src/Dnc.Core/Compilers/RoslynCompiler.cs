using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Compilers
{
    public class RoslynCompiler
        : ICompiler
    {
        public async Task<T> RunAsync<T>(string script,
            object arg=null,
            string nameSpace=null,
            params Assembly[] references)
        {
            var state = await CSharpScript.RunAsync<T>(script,
                  ScriptOptions.Default
                  .WithReferences(references)
                  .WithImports(nameSpace),
                  globals:arg,
                  globalsType:arg.GetType());

            return state.ReturnValue;
        }
    }
}
