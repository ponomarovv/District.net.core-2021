using MVVMExample.UI.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMExample.UI.ViewModel.Entity
{
    public class LoginUser : ViewModelOverrideBase
    {
        private string _login;
        private string _password;

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                RaisePropertyChanged(nameof(Login));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                RaisePropertyChanged(nameof(Password));
            }
        }
    }
    public class User: LoginUser
    {
        private string _firstName;
        private string _lastName;
        private string _confirmPassword;


        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                RaisePropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                RaisePropertyChanged(nameof(LastName));
            }
        }

        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                _confirmPassword = value;
                RaisePropertyChanged(nameof(ConfirmPassword));
            }
        }
    }
}
