using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.SeedWork
{
    public class SysSetting
        : Entity
    {
        public string Key { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
    }
}
