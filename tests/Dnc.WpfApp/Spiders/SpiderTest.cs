using Dnc.Spiders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.WpfApp.Spiders
{
    public class SpiderTest
    {
        private readonly ISpider _spider;
        public SpiderTest(ISpider spider)
        {
            _spider = spider;
        }
        public async Task TestAsync()
        {
            await _spider.GetItemsAsync<string>("https://www.qichacha.com/news", ".list-group", ele =>
             {
                 return "";
             });
        }
    }
}
