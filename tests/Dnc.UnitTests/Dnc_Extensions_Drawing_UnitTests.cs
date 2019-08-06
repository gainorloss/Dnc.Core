using Dnc.Drawing;
using Dnc.Test;
using System.Drawing;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Dnc.UnitTests
{
    public class Dnc_Extensions_Drawing_UnitTests
        : UnitTestBase
    {
        public Dnc_Extensions_Drawing_UnitTests(ITestOutputHelper output)
            : base(output)
        {
            Fx.CreateDefaultConstruction()
                .Build();
        }

        [Fact]
        public void AddWatermark()
        {
            var watermark = "营创调味品批发13229196289";
            var dir = @"C:\Users\Administrator\Desktop\tb";

            var processor = new ImageProcessor();
            foreach (var file in Directory.GetFiles(dir))
            {
                var ext = Path.GetExtension(file);
                if (!ext.Equals(".jpg")) continue;

                processor.AddWatermark(file, watermark, Color.Blue, fontSize: 30,watermarkPlacement: WatermarkPlacement.Center);
            }
        }
    }
}
