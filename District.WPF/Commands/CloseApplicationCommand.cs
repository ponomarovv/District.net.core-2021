using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using District.WPF.Commands.Base;


namespace CV19.Infrastructure.Commands
{
    internal class CloseApplicationCommand : Command
    {
        public override bool CanExecute(object parameter) => true;
        
        public override void Execute(object parameter) => Application.Current.Shutdown();

    }
}
