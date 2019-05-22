using Dnc.Seedwork;

namespace Dnc.Biz.Admin
{
    public class SysRole
        : Entity
    {
        public string Name { get; set; }

        public string ParentId { get; set; }
    }
}
