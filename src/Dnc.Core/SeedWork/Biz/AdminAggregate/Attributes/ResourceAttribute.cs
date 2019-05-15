using System;

namespace Dnc.Seedwork
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class ResourceAttribute
        : Attribute
    {
        public ResourceAttribute(string name,
            bool isMenu, 
            string cssClass, 
            string father = null,
            int seq=0)
        {
            Name = name;
            IsMenu = isMenu;
            CssClass = cssClass;
            Father = father;
            Seq = seq;
        }
        public string Name { get; set; }
        public string Father { get; set; }
        public string CssClass { get; set; }
        public bool IsMenu { get; set; }
        public int Seq { get; set; }
    }
}
