/**************************************************************************************
        ImageProcessor.cs:图片处理器类

        Creator:gainorloss CreateTime:2019-08-06
        Copyright (C) gainorloss
*********************************************************************************************/
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Dnc.Drawing
{
    public class ImageProcessor
    {
        /// <summary>
        /// Add watermark.
        /// </summary>
        /// <param name="fileName"></param>
        public MemoryStream AddWatermark(string fileName,
            string watermark,
            Color foregroundColor,
            float fontSize = 12.0f,
            string fontFamily = "微软雅黑",
            WatermarkPlacement watermarkPlacement = WatermarkPlacement.BottomRight)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new System.ArgumentException("message", nameof(fileName));

            if (string.IsNullOrWhiteSpace(watermark))
                throw new System.ArgumentException("message", nameof(watermark));

            var ext = Path.GetExtension(fileName);
            var dirName = Path.GetDirectoryName(fileName);
            var fileNameWithoutExt = Path.GetFileNameWithoutExtension(fileName);

            var saveName = Path.Combine(dirName, $"{fileNameWithoutExt}_wm{ext}");

            var ms = new MemoryStream();
            using (var img = Image.FromStream(File.OpenRead(fileName)))
            using (var g = Graphics.FromImage(img))
            {
                #region font & background.
                var font = new Font(fontFamily, fontSize, FontStyle.Bold, GraphicsUnit.Pixel);
                var foregroundBrush = new SolidBrush(foregroundColor); //笔刷，画文字用
                //Brush blackBrush = new SolidBrush(backgroundColor); //笔刷，画背景用 
                #endregion

                float textWidth = watermark.Length * fontSize; //文本的长度
                                                               //下面定义一个矩形区域，以后在这个矩形里画上白底黑字
                float rectX = 0;
                float rectY = 0;
                float rectWidth = watermark.Length * (fontSize * 1.113f);
                float rectHeight = fontSize * 1.4f;
                //声明矩形域
                RectangleF textArea = new RectangleF(rectX, rectY, rectWidth, rectHeight);

                #region text placement.
                SizeF crSize;
                crSize = g.MeasureString(watermark, font);
                var point = GetRectangleFPoint(watermarkPlacement, img, crSize);
                textArea.X = point.Item1;
                textArea.Y = point.Item2;
                #endregion

                //g.FillRectangle(blackBrush, textArea);
                g.DrawString(watermark, font, foregroundBrush, textArea);
                img.Save(ms, ImageFormat.Png);
                img.Save(saveName, ImageFormat.Png);
                return ms;
            }
        }

        private (float, float) GetRectangleFPoint(WatermarkPlacement watermarkPlacement, Image img, SizeF crSize)
        {
            float xpos = 0;
            float ypos = 0;
            switch (watermarkPlacement)
            {
                case WatermarkPlacement.TopLeft:
                    xpos = img.Width * (float).01;
                    ypos = img.Height * (float).01;
                    break;
                case WatermarkPlacement.Top:
                    xpos = img.Width * (float).50 - (crSize.Width / 2);
                    ypos = img.Height * (float).01;
                    break;
                case WatermarkPlacement.TopRight:
                    xpos = img.Width * (float).99 - crSize.Width;
                    ypos = img.Height * (float).01;
                    break;
                case WatermarkPlacement.Left:
                    xpos = img.Width * (float).01;
                    ypos = img.Height * (float).50 - (crSize.Height / 2);
                    break;
                case WatermarkPlacement.Center:
                    xpos = img.Width * (float).50 - (crSize.Width / 2);
                    ypos = img.Height * (float).50 - (crSize.Height / 2);
                    break;
                case WatermarkPlacement.Right:
                    xpos = img.Width * (float).99 - crSize.Width;
                    ypos = img.Height * (float).50 - (crSize.Height / 2);
                    break;
                case WatermarkPlacement.BottomLeft:
                    xpos = img.Width * (float).01;
                    ypos = img.Height * (float).99 - crSize.Height;
                    break;
                case WatermarkPlacement.BottomCenter:
                    xpos = img.Width * (float).50 - (crSize.Width / 2);
                    ypos = img.Height * (float).99 - crSize.Height;
                    break;
                case WatermarkPlacement.BottomRight:
                default:
                    xpos = img.Width * (float).99 - crSize.Width;
                    ypos = img.Height * (float).99 - crSize.Height;
                    break;
            }
            return (xpos, ypos);
        }
    }
}
