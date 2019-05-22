using Dnc.Seedwork;

namespace Dnc.Biz.Admin
{
    public class SysPermission
        : Entity
    {
        public long RoleId { get; set; }
        public long ResourceId { get; set; }
    }
}
