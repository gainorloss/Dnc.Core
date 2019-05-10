using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Seedwork
{
    public interface ISysUserManager
    {
        Task<(bool Success, string Msg)> SignInAsync(string name, string pwd);

        Task<(bool Success, string Msg)> SignUpAsync(string name);
    }
}
