using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Seedwork
{
    public class SysResource
        : Entity
    {
        public SysResource()
        {
            ResourceId = Guid.NewGuid().ToString("N");
        }

        public SysResource(string name, 
            bool isMenu, 
            string cssClass, 
            string resource, 
            string parentResource = null)
            : this()
        {
            Name = name;
            IsMenu = isMenu;
            CssClass = cssClass;
            Resource = resource;
            Parent = parentResource;
        }
        public string Name { get; set; }
        public bool IsMenu { get; set; }
        public string ResourceId { get; set; }

        public string Resource { get; set; }
        public string ParentResourceId { get; set; }
        public string Parent { get; set; }
        public string CssClass { get; set; }
    }
}
