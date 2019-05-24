using Dnc.Output;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Timers;

namespace Dnc.Output
{
    public class ConsoleOutputHelper
        : IConsoleOutputHelper
    {
        private static object mLock = new object();

        public void Dump<T>(T obj) where T:class
        {
            if (obj == null)
            {
                Debug("Object is null.");
                return;
            }

            var props = typeof(T).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            if (props == null || !props.Any())
            {
                Debug("There is not any properties in this object.");
                return;
            }

            var propMaxLength = props.Max(p => p.Name.Length);
            var output = string.Empty;
            foreach (var prop in props)
            {
                var propValue = prop.GetValue(obj);
                output = $"{prop.Name.PadLeft(propMaxLength,' ')}:{propValue}";
            }
            Debug(output);
        }

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

        public void Debug(string msg)
            => BuildMessageAndOutput(msg, "debg", ConsoleColor.White);

        public void Info(string msg)
            => BuildMessageAndOutput(msg, "info", ConsoleColor.DarkGreen);

        public void Warning(string msg)
            => BuildMessageAndOutput(msg, "warn", ConsoleColor.DarkYellow);

        public void Error(string msg)
            => BuildMessageAndOutput(msg, "err", ConsoleColor.DarkRed);

        #region Helper.
        private void BuildMessageAndOutput(string msg, string tag, ConsoleColor consoleColor)
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
                Console.WriteLine(msg);
                Console.ForegroundColor = oldColor;
            }
        }
        #endregion
    }
}
