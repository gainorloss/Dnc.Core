using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Dnc.WPF.Ui
{
    public static class PageAnimationExtensions
    {
        public static async Task SlideAndFadeInAsync(this Page page,
            double seconds,
            double offset,
            float decelerationRatio=0.9f)
        {
            var sb = new Storyboard();
            sb.AddSlideFromRight(seconds,offset,decelerationRatio);
            sb.AddFadeIn(seconds);
            sb.Begin(page);
            page.Visibility =Visibility.Visible;

            await Task.Delay((int)seconds*1000);
        }

        public static async Task SlideAndFadeOutAsync(this Page page,
            double seconds,
            double offset,
            float decelerationRatio = 0.9f)
        {
            var sb = new Storyboard();
            sb.AddSlideToLeft(seconds, offset, decelerationRatio);
            sb.AddFadeOut(seconds);
            sb.Begin(page);
            page.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds * 1000);
        }
    }
}
