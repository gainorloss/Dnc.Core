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
        public Window Window { get; set; }
        public MainWindowVm(Window window)
        {
            Window = window;
        }

    }
}
