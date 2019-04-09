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
    /// <summary>
    /// The basic class for a <see cref="Page"/>.
    /// </summary>
    public class BasePage
        : Page
    {
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        public double SlideSeconds { get; set; } = 0.8;

        public BasePage()
        {
            if (PageLoadAnimation != PageAnimation.None)
                Visibility = Visibility.Collapsed;

            Loaded += BasePage_Loaded;
        }

        private async void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            await AnimateIn();
        }

        public async Task AnimateIn()
        {
            if (PageLoadAnimation == PageAnimation.None)
                return;

            switch (PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:
                    var sb = new Storyboard();

                    var anim = new ThicknessAnimation()
                    {
                        Duration = TimeSpan.FromSeconds(SlideSeconds),
                        DecelerationRatio = 0.9f,
                        From = new Thickness(WindowWidth, 0, -WindowWidth, 0),
                        To = new Thickness(0)
                    };
                    Storyboard.SetTargetProperty(anim, new PropertyPath("Margin"));
                    sb.Children.Add(anim);

                    sb.Begin(this);

                    Visibility = Visibility.Visible;

                    await Task.Delay((int)SlideSeconds*1000);

                    break;
                case PageAnimation.SlideAndFadeOutToLeft:
                    break;
                default:
                    break;
            }
        }
    }
}
