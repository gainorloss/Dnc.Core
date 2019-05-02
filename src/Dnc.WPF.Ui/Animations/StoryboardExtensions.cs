using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace Dnc.WPF.Ui
{
    /// <summary>
    /// Extension methods for a <see cref="Storyboard"/>.
    /// </summary>
    public static class StoryboardExtensions
    {
        /// <summary>
        /// Slide from right.
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="seconds"></param>
        /// <param name="offset"></param>
        /// <param name="decelerationRatio"></param>
        public static void AddSlideFromRight(this Storyboard sb,
            double seconds,
            double offset,
            float decelerationRatio = 0.9f)
        {
            var anim = new ThicknessAnimation()
            {
                DecelerationRatio = decelerationRatio,
                Duration = TimeSpan.FromSeconds(seconds),
                From = new Thickness(offset,0,-offset,0),
                To=new Thickness(0)
            };

            Storyboard.SetTargetProperty(anim,new PropertyPath("Margin"));

            sb.Children.Add(anim);
        }

        /// <summary>
        /// Fade in.
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="seconds"></param>
        public static void AddFadeIn(this Storyboard sb,
            double seconds)
        {
            var anim = new DoubleAnimation()
            {
                Duration = TimeSpan.FromSeconds(seconds),
                From = 0,
                To = 1
            };

            Storyboard.SetTargetProperty(anim, new PropertyPath("Opacity"));

            sb.Children.Add(anim);
        }

        /// <summary>
        /// Slide to left.
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="seconds"></param>
        /// <param name="offset"></param>
        /// <param name="decelerationRatio"></param>
        public static void AddSlideToLeft(this Storyboard sb,
            double seconds,
            double offset,
            float decelerationRatio = 0.9f)
        {
            var anim = new ThicknessAnimation()
            {
                DecelerationRatio = decelerationRatio,
                Duration = TimeSpan.FromSeconds(seconds),
                To = new Thickness(-offset, 0, offset, 0),
                From = new Thickness(0)
            };

            Storyboard.SetTargetProperty(anim, new PropertyPath("Margin"));

            sb.Children.Add(anim);
        }

        /// <summary>
        /// Fade out.
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="seconds"></param>
        public static void AddFadeOut(this Storyboard sb,
            double seconds)
        {
            var anim = new DoubleAnimation()
            {
                Duration = TimeSpan.FromSeconds(seconds),
                From = 1,
                To = 0
            };

            Storyboard.SetTargetProperty(anim, new PropertyPath("Opacity"));

            sb.Children.Add(anim);
        }
    }
}
