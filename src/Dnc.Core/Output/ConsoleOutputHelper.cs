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
    }
}
