using MVVMExample.UI.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMExample.UI.ViewModel.Entity
{
    public enum ControlType
    {
        Machinery,
        Accessories,
        Other,
        Login,
        Forget
    }
    public class ProductEntity : ViewModelOverrideBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PathImage { get; set; }
        public decimal Price { get; set; }
        public ControlType ProductType { get; set; }
    }
}
