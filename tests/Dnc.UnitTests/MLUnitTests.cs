using Dnc.ML;
using Dnc.Test;
using System.Linq;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace Dnc.UnitTests
{
    public class MLUnitTests
        : UnitTestBase
    {
        public MLUnitTests(ITestOutputHelper output)
            : base(output)
        { }

        [Fact]
        public void PredictHousePrice()
        {
            HouseData[] houseData = {
               new HouseData() { Size = 1.1F, Price = 1.2F },
               new HouseData() { Size = 1.9F, Price = 2.3F },
               new HouseData() { Size = 2.8F, Price = 3.0F },
               new HouseData() { Size = 3.4F, Price = 3.7F } };

            var engine = new PredictionEngineBuilder<HouseData, Prediction>()
                .Build(catalog => catalog.LoadFromEnumerable(houseData));

            var prediction = engine.Predict(new HouseData() { Size = 2.5F });
            _output.WriteLine($"{prediction.Price}");
        }
    }
}
