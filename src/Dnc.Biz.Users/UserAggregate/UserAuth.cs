using Dnc.Seedwork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Biz.Users
{
    public class UserAuth
         : Entity
    {
        public long UserId { get; set; }

        /// <summary>
        /// 登录类型
        /// </summary>
        public IdentityType IdentityType { get; set; }

        /// <summary>
        /// 标识（手机、邮箱、用户名或者第三方应用的唯一标识）
        /// </summary>
        public string Identifier { get; set; }
        
        /// <summary>
        /// 密码凭证（站外保存密码，站外的不保存货保存token）
        /// </summary>
        public string Credential { get; set; }
    }
}
