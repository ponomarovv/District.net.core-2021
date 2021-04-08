using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMExample.UI.Abstract.Common.Results
{
    public class DataResult<T>:Result
    {
        public T Data { get; set; }

        public static DataResult<T> Fail()
        {
            return new DataResult<T>()
            {
                Success = false,
                Data =default(T)
            };
        }
    }
}
