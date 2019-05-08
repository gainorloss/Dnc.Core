using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace Dnc.Test
{
    public class UnitTestBase
    {
        protected ITestOutputHelper _output;
        public UnitTestBase(ITestOutputHelper output)
        {
            _output = output;
        }
    }
}
