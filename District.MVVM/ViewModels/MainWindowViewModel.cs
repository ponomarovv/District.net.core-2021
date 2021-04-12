
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Windows;
using System.Windows.Input;
using District.MVVM.Commands;


namespace District.MVVM
{
    internal class MainWindowViewModel : ViewModel
    {


        #region Команды

        #region CloseApplicationCommand

        public ICommand CloseApplicationCommand   { get; }

        private bool CanCloseApplicationCommandExecute(object p) => true;


        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }

        #endregion


 
        #endregion

        public MainWindowViewModel()
        {
            #region Команды

            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            

            #endregion

           
        }


    }
}
