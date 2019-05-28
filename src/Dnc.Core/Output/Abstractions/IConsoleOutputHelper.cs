using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Output
{
    /// <summary>
    /// 【Constraint for a <see cref="Console"/> outputting】:
    /// output image;
    /// debug:<see cref="ConsoleColor.White"/>;
    /// info:<see cref="ConsoleColor.DarkGreen"/>;
    /// warning:<see cref="ConsoleColor.DarkYellow"/>;
    /// error:<see cref="ConsoleColor.DarkRed"/>;
    /// eg:<see cref="IConsoleOutputHelper"/>.Info(【msg】,【title="Framework"】).
    /// </summary>
    public interface IConsoleOutputHelper
         : IPlugin
    {
        void Dump<T>(T obj) where T:class;

        void OutputImage(string imgPath);

        /// <summary>
        /// Debug:<see cref="ConsoleColor.White"/>.
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="title"></param>
        void Debug(string msg);

        /// <summary>
        /// Info:green.
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="title"></param>

        void Info(string msg);

        /// <summary>
        /// Warning:yellow.
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="title"></param>

        void Warning(string msg);

        /// <summary>
        /// Error:red.
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="title"></param>
        void Error(string msg);

        /// <summary>
        /// Set console title.
        /// </summary>
        /// <param name="title"></param>
        void SetTitle(string title = "dotnetapp");
    }
}
