using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

namespace Dnc.WPF.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class NotificationObject
        : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //protected Task RunCmd(Expression<Func<bool>> updateFlags, Action action)
        //{
        //    var expression = (LambdaExpression)updateFlags.Body as Expression;

        //}
    }
}
