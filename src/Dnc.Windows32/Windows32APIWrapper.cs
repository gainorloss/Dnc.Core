using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Dnc.Windows32
{
    public class Windows32APIWrapper
        : IWindows32APIWrapper
    {
        #region Members.

        const uint PROCESS_ALL_ACCESS = 0x001F0FFF;
        const uint KEYEVENTF_EXTENDEDKEY = 0x1;
        const uint KEYEVENTF_KEYUP = 0x2;
        //private readonly int MOUSEEVENTF_LEFTDOWN = 0x2;
        //private readonly int MOUSEEVENTF_LEFTUP = 0x4;
        const uint KBC_KEY_CMD = 0x64;
        const uint KBC_KEY_DATA = 0x60;
        #endregion

        //获取窗体的进程标识ID
        public  int GetPid(string windowTitle)
        {
            int rs = 0;
            Process[] arrayProcess = Process.GetProcesses();
            foreach (Process p in arrayProcess)
            {
                if (p.MainWindowTitle.IndexOf(windowTitle) != -1)
                {
                    rs = p.Id;
                    break;
                }
            }

            return rs;
        }

        //根据进程名获取PID
        public  int GetPidByProcessName(string processName)
        {
            Process[] arrayProcess = Process.GetProcessesByName(processName);

            foreach (Process p in arrayProcess)
            {
                return p.Id;
            }
            return 0;
        }

        //根据窗体标题查找窗口句柄（支持模糊匹配）
        public  IntPtr FindWindow(string title)
        {
            Process[] ps = Process.GetProcesses();
            foreach (Process p in ps)
            {
                if (p.MainWindowTitle.IndexOf(title) != -1)
                {
                    return p.MainWindowHandle;
                }
            }
            return IntPtr.Zero;
        }

        //将值写入指定内存地址中
        public  void WriteMemoryValue(int baseAddress, string processName, int value)
        {
            IntPtr hProcess = Windows32API.OpenProcess(0x1F0FFF, false, GetPid(processName)); //0x1F0FFF 最高权限
            Windows32API.WriteProcessMemory(hProcess, (IntPtr)baseAddress, new int[] { value }, 4, IntPtr.Zero);
            Windows32API.CloseHandle(hProcess);
        }

        public int GetHandleByProcessName(string processName)
        {
            var processes = Process.GetProcessesByName(processName);
            var process = processes.FirstOrDefault();
            if (process == null)
                throw new Exception($"Process whose name is {processName} is not found.");
            return Windows32API.OpenProcess(0x1F0FFF, 0, process.Id);
        }

        public int ReadIntValue(int handle, int add)
        {
            int[] r = new int[1];

            try
            {
                Windows32API.ReadProcessMemory(handle, add, r, 4, 0);
                return r[0];
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public string ReadStringValue(int handle, int add)
        {
            byte[] b = new byte[1];

            try
            {
                Windows32API.ReadProcessMemory(handle, add, b, 4, 0);

                var temp = Encoding.Unicode.GetString(b);
                return temp.Split('\0')[0];
            }
            catch (Exception)
            {
                return "";
            }
        }

        public void Inject(int handle, byte[] bytes)
        {
            var addr = Windows32API.VirtualAllocEx(handle, 0, bytes.Length, 0x1000, 0x40);
            Windows32API.WriteProcessMemory(handle, addr, bytes, bytes.Length, 0);
            int threadId = 0;
            int hThread = Windows32API.CreateRemoteThread(handle, 0, 0, addr, 0, 0,ref threadId);
            Windows32API.VirtualFreeEx(handle,addr, 0, 0x8000);
            Windows32API.CloseHandle(hThread);
        }

        /// <summary>
        /// 获取键盘状态
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public bool GetKeyState(VirtualKeys Key)
        {
            return (Windows32API.GetKeyState((int)Key) == 1);
        }
        /// <summary>
        /// 发送键盘事件
        /// </summary>
        /// <returns></returns>
        public void Send(VirtualKeys Key, bool State)
        {
            if (State != GetKeyState(Key))
            {
                byte a = Windows32API.MapVirtualKey((byte)Key, 0);
                Windows32API.Keybd_event((byte)Key, Windows32API.MapVirtualKey((byte)Key, 0), 0, 0);
                System.Threading.Thread.Sleep(1000);
                Windows32API.Keybd_event((byte)Key, Windows32API.MapVirtualKey((byte)Key, 0), KEYEVENTF_KEYUP, 0);
            }
        }
        /// <summary>
        /// 初始化winio
        /// </summary>
        public void SendWinIO()
        {
            if (Windows32API.InitializeWinIo())
            {
                KBCWait4IBE();
            }
        }
        private void KBCWait4IBE() //等待键盘缓冲区为空
        {
            //int[] dwVal = new int[] { 0 };
            int dwVal = 0;
            do
            {
                //这句表示从&H64端口读取一个字节并把读出的数据放到变量dwVal中
                //GetPortVal函数的用法是GetPortVal 端口号,存放读出数据的变量,读入的长度
                bool flag = Windows32API.GetPortVal((IntPtr)0x64, out dwVal, 1);
            }
            while ((dwVal & 0x2) > 0);
        }
        /// <summary>
        /// 模拟键盘标按下
        /// </summary>
        /// <param name="vKeyCoad"></param>
        public void ImitatekeyDown(int vKeyCoad)
        {
            int btScancode = 0;

            btScancode = Windows32API.MapVirtualKey((byte)vKeyCoad, 0);
            // btScancode = vKeyCoad;

            KBCWait4IBE(); // '发送数据前应该先等待键盘缓冲区为空
            Windows32API.SetPortVal(KBC_KEY_CMD, (IntPtr)0xD2, 1);// '发送键盘写入命令
                                                     //SetPortVal函数用于向端口写入数据，它的用法是SetPortVal 端口号,欲写入的数据，写入数据的长度
            KBCWait4IBE();
            Windows32API.SetPortVal(KBC_KEY_DATA, (IntPtr)0xe2, 1);// '写入按键信息,按下键
            KBCWait4IBE(); // '发送数据前应该先等待键盘缓冲区为空
            Windows32API.SetPortVal(KBC_KEY_CMD, (IntPtr)0xD2, 1);// '发送键盘写入命令
                                                     //SetPortVal函数用于向端口写入数据，它的用法是SetPortVal 端口号,欲写入的数据，写入数据的长度
            KBCWait4IBE();
            Windows32API.SetPortVal(KBC_KEY_DATA, (IntPtr)btScancode, 1);// '写入按键信息,按下键

        }
        /// <summary>
        /// 模拟键盘弹出
        /// </summary>
        /// <param name="vKeyCoad"></param>
        public void ImitatekeyUp(int vKeyCoad)
        {
            int btScancode = 0;
            btScancode = Windows32API.MapVirtualKey((byte)vKeyCoad, 0);
            //btScancode = vKeyCoad;

            KBCWait4IBE(); // '发送数据前应该先等待键盘缓冲区为空
            Windows32API.SetPortVal(KBC_KEY_CMD, (IntPtr)0xD2, 1); //'发送键盘写入命令
            KBCWait4IBE();
            Windows32API.SetPortVal(KBC_KEY_DATA, (IntPtr)0xe0, 1);// '写入按键信息，释放键
            KBCWait4IBE(); // '发送数据前应该先等待键盘缓冲区为空
            Windows32API.SetPortVal(KBC_KEY_CMD, (IntPtr)0xD2, 1); //'发送键盘写入命令
            KBCWait4IBE();
            Windows32API.SetPortVal(KBC_KEY_DATA, (IntPtr)btScancode, 1);// '写入按键信息，释放键
        }
        /// <summary>
        /// 模拟鼠标按下
        /// </summary>
        /// <param name="vKeyCoad"></param>
        public void ImitageMouseDown(int vKeyCoad)
        {
            int btScancode = 0;

            btScancode = Windows32API.MapVirtualKey((byte)vKeyCoad, 0);
            //btScancode = vKeyCoad;

            KBCWait4IBE(); // '发送数据前应该先等待键盘缓冲区为空
            Windows32API.SetPortVal(KBC_KEY_CMD, (IntPtr)0xD3, 1);// '发送键盘写入命令
                                                     //SetPortVal函数用于向端口写入数据，它的用法是SetPortVal 端口号,欲写入的数据，写入数据的长度
            KBCWait4IBE();
            Windows32API.SetPortVal(KBC_KEY_DATA, (IntPtr)(btScancode | 0x80), 1);// '写入按键信息,按下键

        }
        /// <summary>
        /// 模拟鼠标弹出
        /// </summary>
        /// <param name="vKeyCoad"></param>
        public void ImitageMouseUp(int vKeyCoad)
        {
            int btScancode = 0;
            btScancode = Windows32API.MapVirtualKey((byte)vKeyCoad, 0);
            // btScancode = vKeyCoad;

            KBCWait4IBE(); // '发送数据前应该先等待键盘缓冲区为空
            Windows32API.SetPortVal(KBC_KEY_CMD, (IntPtr)0xD3, 1); //'发送键盘写入命令
            KBCWait4IBE();
            Windows32API.SetPortVal(KBC_KEY_DATA, (IntPtr)(btScancode | 0x80), 1);// '写入按键信息，释放键
        }
    }
}
