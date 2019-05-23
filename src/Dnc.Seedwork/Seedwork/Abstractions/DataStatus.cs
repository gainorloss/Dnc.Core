using System.ComponentModel;

namespace Dnc.Seedwork
{
    /// <summary>
    /// 
    /// </summary>
    public enum DataStatus
    {
        [Description("已删除")]
        Deleted = -1,
        [Description("待审核")]
        UnAudited = 0,
        [Description("已审核")]
        Audited = 1
    }
}