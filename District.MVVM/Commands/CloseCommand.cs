using System;
using System.Windows;
using System.Windows.Input;

namespace District.MVVM.Commands
{
    public class CloseCommand : ICommand

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






































#region MyRegion




//todo something wrong with main window. p id.
//todo something wrong with siege
//todo active command.

//todo dependency inversion

//todo paths on view...
#endregion