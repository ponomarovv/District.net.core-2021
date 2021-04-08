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
    public class ProductService : IProductService
    {
        public  DataResult<List<ProductEntity>> GetAllProducts()
        {
            return new DataResult<List<ProductEntity>>()
            {
                Success = true,
                Data = new List<ProductEntity>(){

                    new ProductEntity()
                    {
                        Id=1,
                        Price=45,
                        Name="SomeName",
                        Description="SomeDescription",
                        PathImage="",
                        ProductType=ControlType.Accessories
                    },
                        new ProductEntity()
                    {
                        Id=1,
                        Price=45,
                        Name="SomeName",
                        Description="SomeDescription",
                        PathImage="",
                        ProductType=ControlType.Machinery
                    },
                            new ProductEntity()
                    {
                        Id=1,
                        Price=45,
                        Name="SomeName",
                        Description="SomeDescription",
                        PathImage="",
                        ProductType=ControlType.Other
                    }
                }
            };
        }
    }
}
