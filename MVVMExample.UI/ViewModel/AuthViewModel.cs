using GalaSoft.MvvmLight.Command;
using MVVMExample.UI.Abstract.Common.Results;
using MVVMExample.UI.Abstract.Service;
using MVVMExample.UI.Service;
using MVVMExample.UI.ViewModel.Base;
using MVVMExample.UI.ViewModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MVVMExample.UI.ViewModel
{
    public class AuthViewModel : ViewModelOverrideBase
    {
        private readonly MainViewModel _mainViewModel;

        private LoginUser _loginUser;
        private User _user;

        private IAuthService _authService;

        public RelayCommand<object> LoginCommand { get; }
        public RelayCommand<object> MoveRegestrationCommand { get; }
        public RelayCommand<object> RegistrationCommand { get; }
        public RelayCommand<object> MoveLoginCommand { get; }
        public RelayCommand<object> ForgetCommand { get; }
        public RelayCommand<object> SentForgetCommand { get; }

        private UserControl _auth;

        public AuthViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;

            _authService = new AuthService(new Validate());

            LoginCommand = new RelayCommand<object>(Login);
            MoveRegestrationCommand = new RelayCommand<object>(MoveRegistration);
            RegistrationCommand = new RelayCommand<object>(Registration);
            MoveLoginCommand = new RelayCommand<object>(MoveLogin);
            ForgetCommand = new RelayCommand<object>(Forget);
            SentForgetCommand = new RelayCommand<object>(SentForget);
            LoginUser = new LoginUser();
            User = new User();

            UserAuth = ViewModelLocator.GetControl(ControlType.Login);
        }


        public UserControl UserAuth
        {
            get => _auth;
            set
            {
                _auth = value;
                RaisePropertyChanged(nameof(UserAuth));
            }
        }

        public User User
        {
            get => _user;
            set
            {
                _user = value;
                RaisePropertyChanged(nameof(User));
            }
        }

        public LoginUser LoginUser
        {
            get => _loginUser;
            set
            {
                _loginUser = value;
                RaisePropertyChanged(nameof(LoginUser));
            }
        }

        private void Login(object obj)
        {
          DataResult<User> result = 
                _authService.Login(LoginUser);

            if(result.Success)
            {
                User = result.Data;
                LoginUser = new LoginUser();
                _mainViewModel.Navigation.NavigateTo(ViewModelLocator.ContentPage);
            }
            else
            {
                MessageBox.Show("не вірні дані");
            }
        }

        private void MoveRegistration(object obj)
        {
        
            _mainViewModel.Navigation.NavigateTo(ViewModelLocator.RegistrationPage);
        }
        private void Registration(object obj)
        {
           Result result =
                _authService.Registration(User);

            if (result.Success)
            {
                MessageBox.Show("Успішно зареєстровані!");

                _mainViewModel.Navigation.NavigateTo(ViewModelLocator.LoginPage);
            }
            else
            {
                MessageBox.Show("не вірні дані");
            }
        }

        private void MoveLogin(object obj)
        {
            _mainViewModel.Navigation.NavigateTo(ViewModelLocator.LoginPage);
        }

        private void Forget(object obj)
        {
            UserAuth = ViewModelLocator.GetControl(ControlType.Forget);
        }

        public void SentForget(object obj)
        {
            Result result = _authService.ForgetPassword(LoginUser.Login);

            if (result.Success)
            {
                MessageBox.Show("Check email");
                UserAuth = ViewModelLocator.GetControl(ControlType.Login);
            }
            else
            {
                MessageBox.Show("incorrect mail");
            }
        }
    }
}
