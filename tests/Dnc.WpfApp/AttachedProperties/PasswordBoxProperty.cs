using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Dnc.WpfApp.AttachedProperties
{
    public class PasswordBoxProperty
    {

        public static DependencyProperty MonitorTextProperty
           = DependencyProperty.RegisterAttached("MonitorText", typeof(bool), typeof(PasswordBoxProperty), new PropertyMetadata(false));

        public void SetMonitorText(PasswordBox passwordBox,bool value)
        {
            passwordBox.SetValue(MonitorTextProperty, value);
        }

        public bool GetMonitorText(PasswordBox passwordBox)
        {
            return (bool)passwordBox.GetValue(MonitorTextProperty);
        }


        public static DependencyProperty HasTextProperty
            = DependencyProperty.RegisterAttached("HasText", typeof(bool), typeof(PasswordBoxProperty), new PropertyMetadata(false));

        public void SetHasText(PasswordBox passwordBox)
        {
            passwordBox.SetValue(HasTextProperty,passwordBox.SecurePassword.Length>0);
        }

        public bool GetHasText(PasswordBox passwordBox)
        {
            return (bool)passwordBox.GetValue(HasTextProperty);
        }
    }
}
