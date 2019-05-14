using System;

namespace Dnc.AspNetCore.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class FunctionAttribute
        : Attribute
    {
        public FunctionAttribute(string name, bool isMenu, string cssClass, string father = null)
        {
            Name = name;
            IsMenu = isMenu;
            CssClass = cssClass;
            Father = father;
        }
        public string Name { get; set; }
        public string Father { get; set; }
        public string CssClass { get; set; }
        public bool IsMenu { get; set; }
    }
}
