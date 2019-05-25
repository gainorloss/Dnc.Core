using Dnc.Seedwork;
using System;

namespace Dnc.Biz.Users
{
    public class AppUser
        : Entity
    {
        public string NickName { get; set; }
        public string RealName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }
        public string Role { get; set; }
        public DateTime RegisterTime { get; set; }
        public string RegisterIP { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public string LastLoginIP { get; set; }
    }
}
