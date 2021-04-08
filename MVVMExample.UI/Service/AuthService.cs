using MVVMExample.UI.Abstract.Common.Results;
using MVVMExample.UI.Abstract.Service;
using MVVMExample.UI.ViewModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMExample.UI.ViewModel
{
    public class AuthService : IAuthService
    {

        private IValidate _validate;

        public AuthService(IValidate validate)
        {
            _validate = validate;
        }

        public Result ForgetPassword(string email)
        {

            //TODO some logic


            return _validate.Email(email);
        }

        public DataResult<User> Login(LoginUser loginUser)
        {
            //TODO validation;
            //TODO get User with db

            Result result = _validate.LoginUser(loginUser);

            if(!result.Success)
            {
                return DataResult<User>.Fail();
            }

            return new DataResult<User>()
            {
                Success = true,
                Data = new User()
                {
                    FirstName = "default",
                    LastName = "default",
                    Login = loginUser.Login,
                    Password = loginUser.Password
                }
            };
        }

        public Result Registration(User user)
        {

            Result result = _validate.RegistrationUser(user);

            if (!result.Success)
            {
                return result;
            }

            return Result.Ok();
        }
    }
}
