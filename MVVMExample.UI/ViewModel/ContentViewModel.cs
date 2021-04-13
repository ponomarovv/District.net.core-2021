using GalaSoft.MvvmLight.Command;
using MVVMExample.UI.Abstract.Service;
using MVVMExample.UI.Service;
using MVVMExample.UI.ViewModel.Base;
using MVVMExample.UI.ViewModel.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MVVMExample.UI.ViewModel
{
    public class ContentViewModel : ViewModelOverrideBase
    {
        private MainViewModel _mainViewModel;

        private ObservableCollection<ProductEntity> _products;
        private ProductEntity _selectProduct;
        private UserControl _userControl;

        private IProductService _productService;

        public RelayCommand<object> LogoutCommand { get; }

        public ContentViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            _productService = new ProductService();
            LogoutCommand = new RelayCommand<object>(Logout);
            Init();
        }

        private void Init()
        {
            var result  = _productService.GetAllProducts();

            if(result.Success)
            {
                Products = new ObservableCollection<ProductEntity>(result.Data);
            }
        }

        public ObservableCollection<ProductEntity> Products
        {
            get => _products;
            set
            {
                _products = value;
                RaisePropertyChanged(nameof(Products));
            }
        }

        public ProductEntity SelectProduct
        {
            get => _selectProduct;
            set
            {
                _selectProduct = value;
                ProductControl = ViewModelLocator.GetControl(_selectProduct.ProductType);
                RaisePropertyChanged(nameof(SelectProduct));
            }
        }

        private void Logout(object  obj)
        {
           
            _mainViewModel.Navigation.NavigateTo(ViewModelLocator.LoginPage);
        }

        public UserControl ProductControl
        {
            get => _userControl;
            set
            {
                _userControl = value;
                RaisePropertyChanged(nameof(ProductControl));
            }
        }
    }
}
