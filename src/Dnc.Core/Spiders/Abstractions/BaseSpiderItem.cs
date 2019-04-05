using Dnc.Spiders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Spiders
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
