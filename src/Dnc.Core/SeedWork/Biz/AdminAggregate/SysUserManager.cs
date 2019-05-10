using Dnc.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Seedwork
{
    public class SysUserManager
        : ISysUserManager
    {
        private const int ErrorTimes = 5;
        private const int LockMinutes = 1;
        private readonly AdminDbContext _ctx;
        public SysUserManager(AdminDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<(bool Success, string Msg)> SignInAsync(string name, string pwd)
        {
            var user = await _ctx.SysUser.SingleOrDefaultAsync(u => u.UName.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (user == null)
                return (false, "该账号尚未注册");

            if (user.IsLocked && user.AllowLoginTime >= DateTime.Now)
                return (false, $"该账号已因登录错误次数过多已被锁定,锁定剩余时间{(user.AllowLoginTime - DateTime.Now).Value.TotalSeconds}秒");

            if (user.DataStatus == DataStatusEnum.Deleted || user.DataStatus == DataStatusEnum.UnAudited)
                return (false, $"该账号因违规已被管理员冻结或者删除");

            if (!user.Pwd.Equals(pwd))
            {
                user.LoginErrNums += 1;
                if (user.LoginErrNums >= ErrorTimes)
                {
                    user.AllowLoginTime = DateTime.Now.AddMinutes(LockMinutes);
                    user.IsLocked = true;
                }
                return (false, $"该账号已因登录错误次数过多已被锁定,将被锁定{LockMinutes * 60}秒");
            }

            user.LoginErrNums = 0;
            user.AllowLoginTime = null;
            user.IsLocked = false;
            return (true, "登录成功");
        }

        public async Task<(bool Success, string Msg)> SignUpAsync(string name)
        {
            var user =await _ctx.SysUser.SingleOrDefaultAsync(u => u.UName.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (user != null)
                return (false, "该账号已被注册");
            var usr = new SysUser()
            {
                UName = name
            };
            await _ctx.SysUser.AddAsync(usr);
            await _ctx.SaveChangesAsync();

            return (true, "注册成功");
        }
    }
}
