using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Windows32
{
    /// <summary>
    /// 鼠标动作枚举
    /// </summary>
    public enum MouseEventFlag : uint
    {
        move = 0x0001,
        leftdown = 0x0002,
        leftup = 0x0004,
        rightdown = 0x0008,
        rightup = 0x0010,
        middledown = 0x0020,
        middleup = 0x0040,
        xdown = 0x0080,
        xup = 0x0100,
        wheel = 0x0800,
        virtualdesk = 0x4000,
        absolute = 0x8000
    }
}
