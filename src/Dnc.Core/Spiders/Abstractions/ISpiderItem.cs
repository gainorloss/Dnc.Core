using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Spiders
{
    public interface ISpiderItem
    {
        DateTime CreateTime { get; set; }

        string Code { get; set; }
    }
}
