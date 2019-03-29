using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Dnc.WPF.ViewModels
{
    public class RelayCmd
        : ICommand
    {
        #region Public event.
        public event EventHandler CanExecuteChanged = (sender, e) => { }; 
        #endregion

        #region Private member.
        private Action mAction;
        #endregion

        #region Ctor.
        public RelayCmd(Action action)
        {
            mAction = action;
        } 
        #endregion

        public bool CanExecute(object parameter)=>true;

        public void Execute(object parameter)
        {
            mAction?.Invoke();
        }
    }
}
