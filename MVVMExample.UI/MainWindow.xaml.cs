﻿using MVVMExample.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVMExample.UI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow :Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainFrame_Loaded(object sender, RoutedEventArgs e)
        {
            (DataContext as MainViewModel)?.Navigation.NavigateTo(ViewModelLocator.LoginPage);
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
