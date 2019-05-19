using System;

namespace Dnc.Spider
{
    public class BaseSpiderItem
        : ISpiderItem
    {
        public DateTime CreateTime { get; set; }
        public string Code { get; set; }

        public BaseSpiderItem()
        {
            CreateTime = DateTime.Now;
            Code = Guid.NewGuid().ToString("N");
        }
    }
}
