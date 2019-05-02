using System;
using System.Runtime.InteropServices;

namespace Dnc.Windows32
{
    public class Windows32API
    {
        #region Public const members.
        public const int OPEN_PROCESS_ALL = 2035711;
        public const int PAGE_READWRITE = 4;
        public const int PROCESS_CREATE_THREAD = 2;
        public const int PROCESS_HEAP_ENTRY_BUSY = 4;
        public const int PROCESS_VM_OPERATION = 8;
        public const int PROCESS_VM_READ = 256;
        public const int PROCESS_VM_WRITE = 32;
        #endregion

        #region Private const members.
        private const int PAGE_EXECUTE_READWRITE = 0x4;
        private const int MEM_COMMIT = 4096;
        private const int MEM_RELEASE = 0x8000;
        private const int MEM_DECOMMIT = 0x4000;
        private const int PROCESS_ALL_ACCESS = 0x1F0FFF;
        #endregion

        #region Find window.
        //查找窗体
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public extern static IntPtr FindWindow(
            string lpClassName,
            string lpWindowName
            );
        #endregion

        #region Get window thread process id.
        //得到目标进程句柄的函数
        [DllImport("USER32.DLL")]
        public extern static int GetWindowThreadProcessId(
            int hwnd,
            ref int lpdwProcessId
            );
        [DllImport("USER32.DLL")]
        public extern static int GetWindowThreadProcessId(
            IntPtr hwnd,
            ref int lpdwProcessId
            );
        #endregion

        #region Open process.
        //打开进程
        [DllImport("kernel32.dll")]
        public extern static int OpenProcess(
           int dwDesiredAccess,
           int bInheritHandle,
           int dwProcessId
           );

        [DllImport("kernel32.dll", EntryPoint = "OpenProcess")]
        public static extern IntPtr OpenProcess
            (
                int dwDesiredAccess,
                bool bInheritHandle,
                int dwProcessId
            );
        [DllImport("kernel32.dll")]
        public extern static IntPtr OpenProcess(
            uint dwDesiredAccess,
            int bInheritHandle,
            uint dwProcessId
            );
        #endregion

        #region Close handle.
        //关闭句柄的函数
        [DllImport("kernel32.dll", EntryPoint = "CloseHandle")]
        public static extern int CloseHandle(
            int hObject
            );

        [DllImport("kernel32.dll")]
        public static extern void CloseHandle
            (
                IntPtr hObject
            );
        #endregion

        #region Read process memory.
        //读内存
        [DllImport("Kernel32.dll ")]
        public static extern Int32 ReadProcessMemory(
            IntPtr hProcess,
            IntPtr lpBaseAddress,
            [In, Out] byte[] buffer,
            int size,
            out IntPtr lpNumberOfBytesWritten
            );

        [DllImport("kernel32.dll", EntryPoint = "ReadProcessMemory")]
        public static extern bool ReadProcessMemory
            (
                IntPtr hProcess,
                IntPtr lpBaseAddress,
                IntPtr lpBuffer,
                int nSize,
                IntPtr lpNumberOfBytesRead
            );
        [DllImport("Kernel32.dll ")]
        public static extern Int32 ReadProcessMemory(
            int hProcess,
            int lpBaseAddress,
            ref int buffer,
            //byte[] buffer,
            int size,
            int lpNumberOfBytesWritten
            );
        [DllImport("Kernel32.dll ")]
        public static extern int ReadProcessMemory(
            int hProcess,
            int lpBaseAddress,
            byte[] buffer,
            int size,
            int lpNumberOfBytesWritten
            );
        [DllImport("Kernel32.dll ")]
        public static extern Int32 ReadProcessMemory(
            int hProcess,
            int lpBaseAddress,
             int[] buffer,
            int size,
            int lpNumberOfBytesWritten
            );
        #endregion

        #region Write process memory.
        //写内存
        [DllImport("kernel32.dll")]
        public static extern Int32 WriteProcessMemory(
            IntPtr hProcess,
            IntPtr lpBaseAddress,
            [In, Out] byte[] buffer,
            int size,
            out IntPtr lpNumberOfBytesWritten
            );

        //写内存
        [DllImport("kernel32.dll", EntryPoint = "WriteProcessMemory")]
        public static extern bool WriteProcessMemory
            (
                IntPtr hProcess,
                IntPtr lpBaseAddress,
                int[] lpBuffer,
                int nSize,
                IntPtr lpNumberOfBytesWritten
            );
        [DllImport("kernel32.dll")]
        public static extern Int32 WriteProcessMemory(
            int hProcess,
            int lpBaseAddress,
            byte[] buffer,
            int size,
            int lpNumberOfBytesWritten
            );
        #endregion

        #region Create thread.
        //创建线程
        [DllImport("kernel32", EntryPoint = "CreateRemoteThread")]
        public static extern int CreateRemoteThread(
            int hProcess,
            int lpThreadAttributes,
            int dwStackSize,
            int lpStartAddress,
            int lpParameter,
            int dwCreationFlags,
            ref int lpThreadId
            );
        #endregion

        #region Allocate ex.
        //开辟指定进程的内存空间
        [DllImport("Kernel32.dll")]
        public static extern System.Int32 VirtualAllocEx(
         System.IntPtr hProcess,
         System.Int32 lpAddress,
         System.Int32 dwSize,
         System.Int16 flAllocationType,
         System.Int16 flProtect
         );

        [DllImport("Kernel32.dll")]
        public static extern System.Int32 VirtualAllocEx(
        int hProcess,
        int lpAddress,
        int dwSize,
        int flAllocationType,
        int flProtect
        );
        #endregion

        #region Free ex.
        //释放内存空间
        [DllImport("Kernel32.dll")]
        public static extern System.Int32 VirtualFreeEx(
        int hProcess,
        int lpAddress,
        int dwSize,
        int flAllocationType
        );
        #endregion

        [DllImport("user32.dll")]
        public static extern bool Setcursorpos(int x, int y);
        [DllImport("user32.dll")]
        public static extern void Mouse_event(MouseEventFlag flags, int dx, int dy, uint data, UIntPtr extrainfo);
        //键盘事件声明
        [DllImport("user32.dll")]
        public static extern byte MapVirtualKey(byte wCode, int wMap);
        [DllImport("user32.dll")]
        public static extern short GetKeyState(int nVirtKey);
        [DllImport("user32.dll")]
        public static extern void Keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
        //键盘事件声明winio
        [DllImport("winio.dll")]
        public static extern bool InitializeWinIo();
        [DllImport("winio.dll")]
        public static extern bool GetPortVal(IntPtr wPortAddr, out int pdwPortVal, byte bSize);
        [DllImport("winio.dll")]
        public static extern bool SetPortVal(uint wPortAddr, IntPtr dwPortVal, byte bSize);
        [DllImport("winio.dll")]
        public static extern byte MapPhysToLin(byte pbPhysAddr, uint dwPhysSize, IntPtr PhysicalMemoryHandle);
        [DllImport("winio.dll")]
        public static extern bool UnmapPhysicalMemory(IntPtr PhysicalMemoryHandle, byte pbLinAddr);
        [DllImport("winio.dll")]
        public static extern bool GetPhysLong(IntPtr pbPhysAddr, byte pdwPhysVal);
        [DllImport("winio.dll")]
        public static extern bool SetPhysLong(IntPtr pbPhysAddr, byte dwPhysVal);
        [DllImport("winio.dll")]
        public static extern void ShutdownWinIo();
    }
}
