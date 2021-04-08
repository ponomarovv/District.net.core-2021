using MVVMExample.UI.Abstract.Common.Results;
using MVVMExample.UI.Abstract.Service;
using MVVMExample.UI.ViewModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMExample.UI.Service
{
    public class Validate : IValidate
    {
        public Result Email(string email)
        {
            if (email == null || email.Length < 10)
            {
                return Result.Fail();
            }

            return Result.Ok();
        }

        public Result LoginUser(LoginUser login)
        {
            if (login == null)
            {
                return Result.Fail();
            }

            System.Reflection.PropertyInfo[] properties =
                login.GetType().GetProperties();

            foreach (var prop in properties)
            {
                object value = prop.GetValue(login);

                if (value == null || value.ToString()?.Length < 2)
                {
                    return Result.Fail();
                }
            }

            return Email(login.Login);
        }

        public Result RegistrationUser(User login)
        {
            if (login == null)
            {
                return Result.Fail();
            }

            System.Reflection.PropertyInfo[] properties =
                login.GetType().GetProperties();

            foreach (var prop in properties)
            {
                object value = prop.GetValue(login);

                if (value == null || value.ToString()?.Length < 2)
                {
                    return Result.Fail();
                }
            }

            return Email(login.Login);
        }
    }
}
