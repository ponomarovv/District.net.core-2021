

using System;
using System.Windows;
using System.Windows.Input;
using District.MVVM;

namespace MVVM
{
    public class CloseCommand :ICommand
    {

            public event EventHandler CanExecuteChanged
            {
                add => CommandManager.RequerySuggested += value;
                remove => CommandManager.RequerySuggested -= value;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                Application.Current.Shutdown();
            }

    }
}