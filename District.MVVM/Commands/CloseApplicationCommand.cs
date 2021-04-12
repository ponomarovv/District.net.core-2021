using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;


namespace District.MVVM.Commands
{
    internal class CloseApplicationCommand : Command
    {
        public override bool CanExecute(object parameter) => true;
        
        public override void Execute(object parameter) => Application.Current.Shutdown();

    }
}
