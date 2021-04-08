using MVVMExample.UI.Abstract.Common.Results;
using MVVMExample.UI.ViewModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMExample.UI.Abstract.Service
{
    public interface IProductService
    {
        DataResult<List<ProductEntity>> GetAllProducts();
    }
}
