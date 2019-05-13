using Dnc.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Dnc.Seedwork
{
    public class SysUserManager
        : ISysUserManager
    {
        private const int ErrorTimes = 5;
        private const int LockMinutes = 1;
        private readonly AbstractAdminDbContext _ctx;
        private readonly HttpContext _httpContext;
        public SysUserManager(AbstractAdminDbContext ctx,
            IHttpContextAccessor httpContextAccessor)
        {
            _ctx = ctx;
            _httpContext = httpContextAccessor.HttpContext;
        }
        public async Task<(bool Success, string Msg)> SignInAsync(string name, string pwd)
        {
            var user = await _ctx.SysUser.SingleOrDefaultAsync(u => u.UName.Equals(name, StringComparison.OrdinalIgnoreCase));
            string message = string.Empty;
            var clientIP = _httpContext.Connection.RemoteIpAddress?.ToString();
            if (user == null)
            {
                message = "该账号尚未注册";
                await AddLoginLog(user.Id, message, clientIP);
                return (false, message);
            }

            if (user.IsLocked && user.AllowLoginTime >= DateTime.Now)
            {
                message = $"该账号已因登录错误次数过多已被锁定,锁定剩余时间{(user.AllowLoginTime - DateTime.Now).Value.TotalSeconds}秒";
                await AddLoginLog(user.Id, message, clientIP);
                return (false, message);
            }

            if (user.DataStatus == DataStatusEnum.Deleted || user.DataStatus == DataStatusEnum.UnAudited)
            {
                message = "该账号因违规已被管理员冻结或者删除";
                await AddLoginLog(user.Id, message, clientIP);
                return (false, message);
            }

            if (!user.Pwd.Equals(pwd))
            {
                user.LoginErrNums += 1;
                if (user.LoginErrNums >= ErrorTimes)
                {
                    user.AllowLoginTime = DateTime.Now.AddMinutes(LockMinutes);
                    user.IsLocked = true;
                }
                message = $"该账号已因登录错误次数过多已被锁定,将被锁定{LockMinutes * 60}秒";
                await AddLoginLog(user.Id, message, clientIP);
                return (false, message);
            }

            user.LoginErrNums = 0;
            user.AllowLoginTime = null;
            user.IsLocked = false;
            user.LastLoginTime = DateTime.Now;
            user.LastLoginIP = clientIP;

            message = "登录成功";
            await AddLoginLog(user.Id, message, clientIP, save: false);

            var token = new SysUserToken(user.Id);
            await _ctx.SysUserToken.AddAsync(token);
            await _ctx.SaveChangesAsync();
            return (true, message);
        }

        public async Task<(bool Success, string Msg)> SignUpAsync(string name)
        {
            var user = await _ctx.SysUser.SingleOrDefaultAsync(u => u.UName.Equals(name, StringComparison.OrdinalIgnoreCase));
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

        private async Task AddLoginLog(long userId, string msg, string ip = null, bool save = true)
        {
            var userLoginLog = new SysUserLoginLog(userId, msg, ip);
            await _ctx.SysUserLoginLog.AddAsync(userLoginLog);

            if (save)
                await _ctx.SaveChangesAsync();
        }
    }
}
