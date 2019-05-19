using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Test
{
    public class UnitTestData
    {
        private readonly IEnumerable<object[]> _testData = new List<object[]>();

        public IEnumerable<object[]> TestData => _testData;
    }
}
