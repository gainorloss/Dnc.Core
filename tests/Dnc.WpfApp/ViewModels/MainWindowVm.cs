using Dnc.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Dnc.WpfApp.ViewModels
{
    public class MainWindowVm
          : NotificationObject
    {
        private Window mWindow { get; set; }
        public MainWindowVm(Window window)
        {
            mWindow = window;
        }

        #region Public props.
        public int ResizeBorder { get; set; } = 6;

        public Thickness ResizeBorderThickness => new Thickness(ResizeBorder);

        public int TitleHeight { get; set; } = 42;

        public GridLength TitleHeightGridLength => new GridLength(TitleHeight + ResizeBorder);

        public int WindowMinimunHeight { get; set; } = 768;
        public int WindowMinimumWidth { get; set; } = 1366;

        private int mOuterMarginSize=10;

        public int OuterMarginSize => mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize;

        public Thickness OuterMarginSizeThickness => new Thickness(OuterMarginSize);

        private int mWindowRadius=10;

        public int WindowRadius => mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius;

        public CornerRadius WindowCornerRadius => new CornerRadius(WindowRadius);

        public Thickness InnerContentPaddingThickness { get; set; } = new Thickness(0);
        #endregion
    }
}
