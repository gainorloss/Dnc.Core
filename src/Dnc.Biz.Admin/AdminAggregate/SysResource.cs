using Dnc.Seedwork;
using System;

namespace Dnc.Biz.Admin
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
            string parentResource = null,
            int seq=0)
            : this()
        {
            Name = name;
            IsMenu = isMenu;
            CssClass = cssClass;
            Resource = resource;
            Parent = parentResource;
            Seq = seq;
        }
        public string Name { get; set; }
        public bool IsMenu { get; set; }
        public string ResourceId { get; set; }

        public string Resource { get; set; }
        public string ParentResourceId { get; set; }
        public string Parent { get; set; }
        public string CssClass { get; set; }
        public int Seq { get; set; }
    }
}
