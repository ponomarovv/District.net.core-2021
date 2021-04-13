using MVVMExample.UI.Abstract.Common.Results;
using MVVMExample.UI.ViewModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMExample.UI.Abstract.Service
{
    public interface IAuthService
    {
        DataResult<User> Login(LoginUser loginUser);
        Result Registration(User user);
        Result ForgetPassword(string email);
    }
}
