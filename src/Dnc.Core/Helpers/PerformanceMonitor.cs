using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Dnc
{
    /// <summary>
    /// Performance test helper.
    /// </summary>
    public class PerformanceMonitor
    {
        private static readonly TimeSpan _preCpuTime;

        static PerformanceMonitor()
        {
            _preCpuTime = TimeSpan.Zero;
        }

        public static string MonitorCurrentProcess(int interval=1000)
        {
            var cur = Process.GetCurrentProcess();
            string log = GetProcessInfo(interval, cur);
            return log;
        }


        public static string MonitorProcessByName(string name,int interval = 1000)
        {
            var processes = Process.GetProcessesByName(name);

            var strs = new List<string>() { string.Empty };
            foreach (var process in processes)
            {
                string str = GetProcessInfo(interval, process);
                strs.Add(str);
            }
            var log = string.Join("\r\n", strs);
            var logger = Framework.Construction.ServiceProvider.GetRequiredService<ILogger>();
            logger.LogInformation(log);
            return log;
        }


        private static string GetProcessInfo(int interval, Process cur)
        {
            var curCpuTime = cur.TotalProcessorTime;
            var val = (curCpuTime - _preCpuTime).TotalMilliseconds / interval / Environment.ProcessorCount;
            var pfPrivate = new PerformanceCounter("Process", "Working Set - Private", cur.ProcessName);
            var pf = new PerformanceCounter("Process", "Working Set", cur.ProcessName);

            var strs = new List<string>() { string.Empty };
            strs.Add($@"----------------------------------------------");
            strs.Add($@"           描述:{cur.ProcessName}");
            strs.Add($@"            PID:{cur.Id}");
            strs.Add($@"      cpu使用率:{val}%");
            strs.Add($@"         句柄数:{cur.HandleCount}");
            strs.Add($@"       窗体标题:{cur.MainWindowTitle}");
            strs.Add($@"         线程数:{cur.Threads.Count}");
            strs.Add($@"        cpu时间:{cur.TotalProcessorTime}");
            strs.Add($@"     进程类内存:{cur.WorkingSet64 / (1024 * 1024):N}M");
            strs.Add($@" 私有工作集内存:{pfPrivate.NextValue() / (1024 * 1024):N}M");
            strs.Add($@"     工作集内存:{pf.NextValue() / (1024 * 1024):N}M");

            var log = string.Join("\r\n", strs);
            var logger = Framework.Construction.ServiceProvider.GetRequiredService<ILogger>();
            logger.LogInformation(log);
            return log;
        }
    }
}
