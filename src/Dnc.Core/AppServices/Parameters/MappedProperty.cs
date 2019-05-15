using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.AppServices
{
    public class MappedProperty
    {
        public MappedProperty(string name,bool revert=false)
        {
            Name = name;
            Revert = revert;
        }
        public string Name { get; set; }
        public bool Revert { get; set; } = false;
    }
}
