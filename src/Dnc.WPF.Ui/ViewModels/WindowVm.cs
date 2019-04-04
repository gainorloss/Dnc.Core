using Dnc.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Dnc.WPF.Ui.ViewModels
{
    public class WindowVm
         : NotificationObject
    {
        private Window mWindow { get; set; }
        public WindowVm(Window window)
        {
            mWindow = window;

            RaisePropertyChanged(nameof(ResizeBorderThickness));
            RaisePropertyChanged(nameof(OuterMarginSize));
            RaisePropertyChanged(nameof(OuterMarginSizeThickness));
            RaisePropertyChanged(nameof(WindowRadius));
            RaisePropertyChanged(nameof(WindowCornerRadius));
        }

        #region Public props.
        public int ResizeBorder { get; set; } = 6;

        public Thickness ResizeBorderThickness => new Thickness(ResizeBorder + OuterMarginSize);

        public int TitleHeight { get; set; } = 42;

        public GridLength TitleHeightGridLength => new GridLength(TitleHeight + ResizeBorder);

        public int WindowMinimunHeight { get; set; } = 768;
        public int WindowMinimumWidth { get; set; } = 1366;

        private int mOuterMarginSize = 10;

        public int OuterMarginSize
        {
            get { return mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize; }
            set { mOuterMarginSize = value; }
        }

        public Thickness OuterMarginSizeThickness => new Thickness(OuterMarginSize);

        private int mWindowRadius = 10;

        public int WindowRadius
        {
            get { return mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius; }
            set { mWindowRadius = value; }
        }

        public CornerRadius WindowCornerRadius => new CornerRadius(WindowRadius);

        public Thickness InnerContentPaddingThickness { get; set; } = new Thickness(0);
        #endregion
    }
}
