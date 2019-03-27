﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using PropertyChanged;

namespace Dnc.WPF.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class NotificationObject
        : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
}
