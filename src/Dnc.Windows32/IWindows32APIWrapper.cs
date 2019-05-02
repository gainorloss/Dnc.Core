using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Windows32
{
    public interface IWindows32APIWrapper
    {
        int GetHandleByProcessName(string processName);

        int ReadIntValue(int handle, int add);

        string ReadStringValue(int handle, int add);

        void Inject(int handle, byte[] bytes);

        /// <summary>
        /// 获取窗体的进程标识ID
        /// </summary>
        /// <param name="windowTitle"></param>
        /// <returns></returns>
        int GetPid(string windowTitle);

        /// <summary>
        /// 根据进程名获取PID
        /// </summary>
        /// <param name="processName"></param>
        /// <returns></returns>
        int GetPidByProcessName(string processName);

        /// <summary>
        /// 根据窗体标题查找窗口句柄（支持模糊匹配）
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        IntPtr FindWindow(string title);

        /// <summary>
        /// 将值写入指定内存地址中
        /// </summary>
        /// <param name="baseAddress"></param>
        /// <param name="processName"></param>
        /// <param name="value"></param>
        void WriteMemoryValue(int baseAddress, string processName, int value);

        /// <summary>
        /// 获取键盘状态
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        bool GetKeyState(VirtualKeys Key);

        /// <summary>
        /// 发送键盘事件
        /// </summary>
        /// <returns></returns>
        void Send(VirtualKeys Key, bool State);

        /// <summary>
        /// 初始化winio
        /// </summary>
        void SendWinIO();

        /// <summary>
        /// 模拟键盘标按下
        /// </summary>
        /// <param name="vKeyCoad"></param>
        void ImitatekeyDown(int vKeyCoad);

        /// <summary>
        /// 模拟键盘弹出
        /// </summary>
        /// <param name="vKeyCoad"></param>
        void ImitatekeyUp(int vKeyCoad);

        /// <summary>
        /// 模拟鼠标按下
        /// </summary>
        /// <param name="vKeyCoad"></param>
        void ImitageMouseDown(int vKeyCoad);

        /// <summary>
        /// 模拟鼠标弹出
        /// </summary>
        /// <param name="vKeyCoad"></param>
        void ImitageMouseUp(int vKeyCoad);
    }
}
