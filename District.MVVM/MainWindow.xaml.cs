using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using District.Bl.Abstract.IServices;
using District.Models.Models;
using Microsoft.Extensions.DependencyInjection;
using MVVM;

namespace District.MVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();


            // Get a local instance of the container
            var container = ((App)App.Current).Container;

            // Request an instance of the ViewModel and set it to the DataContext
            DataContext = ActivatorUtilities.GetServiceOrCreateInstance(container, typeof(ApplicationViewModel));
            //DataContext = new ApplicationViewModel();
        }
    }
}
