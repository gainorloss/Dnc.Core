using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Dnc.WPF.ViewModels
{
    public class RelayParameterizedCmd
        : ICommand
    {
        #region Public event.
        public event EventHandler CanExecuteChanged = (sender, e) => { };
        #endregion

        #region Private member.
        private Action<object> mAction;
        #endregion

        #region Ctor.
        public RelayParameterizedCmd(Action<object> action)
        {
            mAction = action;
        }
        #endregion

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            mAction?.Invoke(parameter);
        }
    }
}
