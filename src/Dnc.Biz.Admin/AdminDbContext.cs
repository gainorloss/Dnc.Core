using Dnc.Data;
using Microsoft.EntityFrameworkCore;

namespace Dnc.Biz.Admin
{
    public abstract class AbstractAdminDbContext
        : ApplicationDbContext
    {
        public AbstractAdminDbContext()
        { }

        public AbstractAdminDbContext(DbContextOptions options)
            : base(options)
        { }

        public virtual DbSet<SysUser> SysUser { get; set; }
        public virtual DbSet<SysUserToken> SysUserToken { get; set; }
        public virtual DbSet<SysUserLoginLog> SysUserLoginLog { get; set; }
        public virtual DbSet<SysRole> SysRole { get; set; }
        public virtual DbSet<SysPermission> SysPermission { get; set; }
        public virtual DbSet<SysResource> SysResource { get; set; }
        public virtual DbSet<SysSetting> SysSetting { get; set; }
        public virtual DbSet<SysDomain> SysDomain { get; set; }
    }
}
