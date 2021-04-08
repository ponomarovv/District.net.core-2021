using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Linq;
using District.Bl.Abstract.IServices;
using District.Bl.Impl.Services;
using District.Models.Models;

namespace MVVM
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private ApartmentModel _selectedApartment;
        private IApartmentService _apartmentService;
        private ObservableCollection<ApartmentModel> _apartments;

        public ObservableCollection<ApartmentModel> Apartments
        {
            get => _apartments;
            set
            {
                _apartments = value;
                OnPropertyChanged(nameof(Apartments));
            } 
        }

        public ApartmentModel SelectedApartment
        {
            get { return _selectedApartment; }
            set
            {
                _selectedApartment = value;
                OnPropertyChanged("SelectedApartment");
            }
        }

        public ApplicationViewModel()
        {
            InitData();
        }

        private async void InitData()
        {
            _apartmentService = new ApartmentService();
            var collection = await _apartmentService.GetAllApartments();
            Apartments = new ObservableCollection<ApartmentModel>(collection);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}