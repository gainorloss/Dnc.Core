using Dnc.Output;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Timers;

namespace Dnc.Output
{
    public class ConsoleOutputHelper
        : IConsoleOutputHelper
    {
        private static object mLock = new object();

        public void OutputImage(string imgPath)
        {
            #region Check image is existed or not.
            if (!File.Exists(imgPath))
                throw new ArgumentException("The image is not existed.");
            #endregion

            #region Delete file before.
            var tmpPath = "badapple.txt";
            if (File.Exists(tmpPath))
                File.Delete(tmpPath);
            #endregion

            #region Write img to text.        
            var width = 0;
            var height = 0;

            using (var fs = new FileStream(tmpPath,
                   FileMode.OpenOrCreate,
                   FileAccess.Write))
            {
                using (var sw = new StreamWriter(fs))
                {
                    var bitmap = new Bitmap(imgPath, true);

                    width = bitmap.Width;
                    height = bitmap.Height;

                    for (int y = 0; y < height; y++)
                    {
                        var line = string.Empty;
                        for (int x = 0; x < width; x++)
                        {
                            var color = bitmap.GetPixel(x, y);
                            if (color.R > 200)
                            {
                                line = $"{line}#";
                            }
                            else
                            {
                                line = $"{line} ";
                            }
                        }
                        sw.WriteLine(line);
                    }
                }
            }
            #endregion

            #region Clear console & Set console size and title.
            Console.Clear();
            Console.Title = "Bad Apple (cmd ver.) Powered by DotnetCore.";
            #endregion

            #region Read & output text to console.

            var lines = File.ReadAllText(tmpPath);
            Console.Write(lines);
            #endregion
        }

        public void Debug(string msg, string title = "Framework")
            => BuildMessageAndOutput(msg, title, "debg", ConsoleColor.White);

        public void Info(string msg, string title = "Framework")
            => BuildMessageAndOutput(msg, title, "info", ConsoleColor.DarkGreen);

        public void Warning(string msg, string title = "Framework")
            => BuildMessageAndOutput(msg, title, "warn", ConsoleColor.DarkYellow);

        public void Error(string msg, string title = "Framework")
            => BuildMessageAndOutput(msg, title, "err", ConsoleColor.DarkRed);

        #region Helper.
        private void BuildMessageAndOutput(string msg, string title, string tag, ConsoleColor consoleColor)
        {
            lock (mLock)
            {
                var oldColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("[");
                Console.Write($"{DateTime.Now.ToLongTimeString()}");
                Console.ForegroundColor = consoleColor;
                Console.Write($" {tag.PadRight(4, ' ').ToUpper()}");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("]");
                msg = $" {title}：{msg}";
                Console.WriteLine(msg);
                Console.ForegroundColor = oldColor;
            }
        }
        #endregion
    }
}
