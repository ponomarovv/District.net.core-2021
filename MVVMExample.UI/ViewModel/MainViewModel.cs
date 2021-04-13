using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using MVVMExample.UI.ViewModel.Base;
using MVVMExample.UI.ViewModel.Entity;
using System.Windows.Controls;

namespace MVVMExample.UI.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelOverrideBase
    {
        public INavigationService Navigation;

        private AuthViewModel _authViewModel;
        private ContentViewModel _contentViewModel;
     

        public MainViewModel(INavigationService navigationService)
        {
            Navigation = navigationService;
            AuthViewModel = new AuthViewModel(this);
            ContentViewModel = new ContentViewModel(this);
            
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }

        public AuthViewModel AuthViewModel
        {
            get => _authViewModel;
            set
            {
                _authViewModel = value;
                RaisePropertyChanged(nameof(AuthViewModel));
            }
        }


        public ContentViewModel ContentViewModel
        {
            get => _contentViewModel;
            set
            {
                _contentViewModel = value;
                RaisePropertyChanged(nameof(ContentViewModel));
            }
        }
    }
}