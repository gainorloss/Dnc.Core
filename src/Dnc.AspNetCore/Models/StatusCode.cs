using System.ComponentModel;

namespace Dnc.AspNetCore.Models
{
    public enum StatusCode
    {
        [Description("成功")]
        Success = 100,

        [Description("失败")]
        Failed = 200
    }
}