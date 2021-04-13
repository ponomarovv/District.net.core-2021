using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using MVVMExample.UI.Controls.UserControl;
using MVVMExample.UI.Infrastructure;
using MVVMExample.UI.ViewModel.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace MVVMExample.UI.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        private static Dictionary<ControlType, Lazy<UserControl>> controls =
            new Dictionary<ControlType, Lazy<UserControl>>();

        public const string LoginPage = "LoginPage";
        public const string RegistrationPage = "Registration";
        public const string ContentPage = "ContentPage";

        

        public ViewModelLocator()
        {
            NavigationService navigationService = new NavigationService();
            SimpleIoc.Default.Register<INavigationService>(() => navigationService);

            navigationService.Configure(LoginPage, new Uri("../Pages/Auth/LoginPage.xaml", UriKind.Relative));
            navigationService.Configure(RegistrationPage, new Uri("../Pages/Auth/Registration.xaml", UriKind.Relative));
            navigationService.Configure(ContentPage, new Uri("../Pages/Content/ContentPage.xaml", UriKind.Relative));

            controls.Add(ControlType.Accessories, new Lazy<UserControl>(() => new AccessoriesControl()));
            controls.Add(ControlType.Machinery, new Lazy<UserControl>(() => new MachineryControl()));
            controls.Add(ControlType.Other, new Lazy<UserControl>(() => new OtherControl()));
            controls.Add(ControlType.Forget, new Lazy<UserControl>(() => new ForgetPasswordControl()));
            controls.Add(ControlType.Login, new Lazy<UserControl>(() => new LoginControl()));
            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return SimpleIoc.Default.GetInstance<MainViewModel>();
            }
        }
        

        public static UserControl GetControl(ControlType controlType)
        {
            if(controls.ContainsKey(controlType))
            {
                return controls[controlType].Value;
            }

            return new UserControl();
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}