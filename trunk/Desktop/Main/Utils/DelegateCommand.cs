using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Main
{
    public class DelegateCommand : ICommand
    {
        private Action CallDelegate { get; set; }

        public DelegateCommand(Action call)
        {
            CallDelegate = call;
        }

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            CallDelegate();
        }

        #endregion

        private void NotifyCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, new EventArgs());
        }
    }
}
