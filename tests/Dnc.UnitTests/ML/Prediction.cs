using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.UnitTests
{
    class Prediction
    {
        [ColumnName("Score")]
        public  float Price { get; set; }
    }
}
